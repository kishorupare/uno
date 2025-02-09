﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using Windows.UI.Xaml;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.Extensions;
using UIKit;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Input;
using CoreGraphics;
using Uno.Extensions.Specialized;

namespace Windows.UI.Xaml.Controls
{
	public partial class Picker : UIPickerView, ISelector, IFrameworkElement, DependencyObject
	{
		public event SelectionChangedEventHandler SelectionChanged;

		public Picker()
		{
			IFrameworkElementHelper.Initialize(this);
			this.InitializeBinder();

			AutoresizingMask = UIViewAutoresizing.None;
			SetupSelectionIndicator();

			OnDisplayMemberPathChangedPartial(string.Empty, this.DisplayMemberPath);

			this.Model = new PickerModel(this);
		}

		private void SetupSelectionIndicator()
		{
			// The "selection indicator" refers the the thin lines above and below the selected item in the spinner.

			// Setting this flag should be enough but it isn't.
			ShowSelectionIndicator = true;

			// Selecting the first item strangely fixes the selection not showing otherwise.
			// See this for more info: https://stackoverflow.com/questions/39564660/uipickerview-selection-indicator-not-visible-in-ios10
			Select(row: 0, component: 0, animated: false);
		}

		public override CGSize SizeThatFits(CGSize size)
		{
			size = IFrameworkElementHelper.SizeThatFits(this, size);

			if (nfloat.IsPositiveInfinity(size.Height) || nfloat.IsPositiveInfinity(size.Width))
			{
				// Changes from IOS 9 doc.
				// See following
				// https://jira.appcelerator.org/browse/TIMOB-19203 
				// https://developer.apple.com/library/prerelease/ios/releasenotes/General/RN-iOSSDK-9.0/
				size = base.SizeThatFits(size);
			}


			return size;
		}

		public object[] Items { get; private set; } = new object[] { null }; // ensure there's always a null present to allow deselection
		
		partial void OnItemsSourceChangedPartialNative(object oldItemsSource, object newItemsSource)
		{
			if (oldItemsSource is INotifyCollectionChanged oldObservableCollection)
			{
				oldObservableCollection.CollectionChanged -= OnItemSourceChanged;
			}

			if (newItemsSource is INotifyCollectionChanged newObservableCollection)
			{
				newObservableCollection.CollectionChanged += OnItemSourceChanged;
			}

			OnItemSourceChanged(newItemsSource, null);
		}

		private void OnItemSourceChanged(object collection, NotifyCollectionChangedEventArgs _)
		{
			Items = (collection as IEnumerable)?.ToObjectArray() ?? new object[0];
			ReloadAllComponents();

			if (!Items.Contains(SelectedItem))
			{
				SelectedItem = Items.FirstOrDefault();
			}
		}

		partial void OnSelectedItemChangedPartial(object oldSelectedItem, object newSelectedItem)
		{
			var row = Items?.IndexOf(newSelectedItem) ?? -1;
			if (row == -1) // item not found
			{
				var firstItem = Items?.FirstOrDefault();
				if (firstItem != newSelectedItem) // We compare to 'newSelectedItem' so we allow them to be both 'null'
				{
					SelectedItem = firstItem;
					return;
				}
			}

			Select(row, component: 0, animated: true);

			SelectionChanged?.Invoke(
				this,
				// TODO: Add multi-selection support
				new SelectionChangedEventArgs(
					new[] { oldSelectedItem },
					new[] { newSelectedItem }
				)
			);
		}
		
		partial void OnDisplayMemberPathChangedPartial(string oldDisplayMemberPath, string newDisplayMemberPath)
		{
			this.UpdateItemTemplateSelectorForDisplayMemberPath(newDisplayMemberPath);
		}
	}
}
