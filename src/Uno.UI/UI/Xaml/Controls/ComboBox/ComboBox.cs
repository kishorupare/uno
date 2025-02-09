﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Uno.Client;
using System.Collections;
using Uno.UI.Controls;
using Uno.Extensions;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Input;
using Uno.Logging;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.Foundation;
using Uno.UI;
using System.Linq;
using Windows.UI.ViewManagement;
using Microsoft.Extensions.Logging;

#if __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#endif

namespace Windows.UI.Xaml.Controls
{
	// Temporarily inheriting from ListViewBase instead of Selector to leverage existing selection and virtualization code
	public partial class ComboBox : ListViewBase // TODO: Selector
	{
		public event EventHandler<object> DropDownClosed;
		public event EventHandler<object> DropDownOpened;

		private IPopup _popup;
		private Border _popupBorder;
		private ContentPresenter _contentPresenter;
		private ContentPresenter _headerContentPresenter;

		public ComboBox()
		{
			IsItemClickEnabled = true;
		}

		public global::Windows.UI.Xaml.Controls.Primitives.ComboBoxTemplateSettings TemplateSettings { get; } = new Primitives.ComboBoxTemplateSettings();

		protected override DependencyObject GetContainerForItemOverride() => new ComboBoxItem { IsGeneratedContainer = true };

		protected override bool IsItemItsOwnContainerOverride(object item) => item is ComboBoxItem;

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (_popup is PopupBase oldPopup)
			{
				oldPopup.CustomLayouter = null;
			}

			_popup = this.GetTemplateChild("Popup") as IPopup;
			_popupBorder = this.GetTemplateChild("PopupBorder") as Border;
			_contentPresenter = this.GetTemplateChild("ContentPresenter") as ContentPresenter;

			if (_popup is PopupBase popup)
			{
				popup.CustomLayouter = new DropDownLayouter(this, popup);
			}

			UpdateHeaderVisibility();
			UpdateContentPresenter();
		}

#if __ANDROID__
		protected override void OnPointerPressed(PointerRoutedEventArgs args)
		{
			base.OnPointerPressed(args);

			// For some reasons, PointerReleased is not raised unless PointerPressed is Handled.
			args.Handled = true;
		}
#endif

		protected override void OnLoaded()
		{
			base.OnLoaded();

			UpdateDropDownState();

			if (_popup != null)
			{
				_popup.Closed += OnPopupClosed;
				_popup.Opened += OnPopupOpened;
			}

			Xaml.Window.Current.SizeChanged += OnWindowSizeChanged;
		}

		protected override void OnUnloaded()
		{
			base.OnUnloaded();

			if (_popup != null)
			{
				_popup.Closed -= OnPopupClosed;
				_popup.Opened -= OnPopupOpened;
			}

			Xaml.Window.Current.SizeChanged -= OnWindowSizeChanged;
		}

		private void OnWindowSizeChanged(object sender, Core.WindowSizeChangedEventArgs e)
		{
			IsDropDownOpen = false;
		}

		private void OnPopupOpened(object sender, object e)
		{
			IsDropDownOpen = true;
		}

		private void OnPopupClosed(object sender, object e)
		{
			IsDropDownOpen = false;
		}

		protected override void OnHeaderChanged(object oldHeader, object newHeader)
		{
			base.OnHeaderChanged(oldHeader, newHeader);
			UpdateHeaderVisibility();
		}

		protected override void OnHeaderTemplateChanged(DataTemplate oldHeaderTemplate, DataTemplate newHeaderTemplate)
		{
			base.OnHeaderTemplateChanged(oldHeaderTemplate, newHeaderTemplate);
			UpdateHeaderVisibility();
		}

		private void UpdateHeaderVisibility()
		{
			var headerVisibility = (Header != null || HeaderTemplate != null)
					? Visibility.Visible
					: Visibility.Collapsed;

			if (headerVisibility == Visibility.Visible && _headerContentPresenter == null)
			{
				_headerContentPresenter = this.GetTemplateChild("HeaderContentPresenter") as ContentPresenter;
				if (_headerContentPresenter != null)
				{
					// On Windows, all interactions involving the HeaderContentPresenter don't seem to affect the ComboBox.
					// For example, hovering/pressing doesn't trigger the PointOver/Pressed visual states. Tapping on it doesn't open the drop down.
					// This is true even if the Background of the root of ComboBox's template (which contains the HeaderContentPresenter) is set. 
					// Interaction with any other part of the control (including the root) triggers the corresponding visual states and actions.
					// It doesn't seem like the HeaderContentPresenter consumes (Handled = true) events because they are properly routed to the ComboBox.

					// My guess is that ComboBox checks whether the OriginalSource of Pointer events is a child of HeaderContentPresenter.

					// Because routed events are not implemented yet, the easy workaround is to prevent HeaderContentPresenter from being hit. 
					// This only works if the background of the root of ComboBox's template is null (which is the case by default).
					_headerContentPresenter.IsHitTestVisible = false;
				}
			}

			if (_headerContentPresenter != null)
			{
				_headerContentPresenter.Visibility = headerVisibility;
			}
		}

		internal override void OnSelectedItemChanged(object oldSelectedItem, object selectedItem)
		{
			base.OnSelectedItemChanged(oldSelectedItem, selectedItem);
			UpdateContentPresenter();
		}

		internal override void OnItemClicked(int clickedIndex)
		{
			base.OnItemClicked(clickedIndex);
			IsDropDownOpen = false;
		}

		private void UpdateContentPresenter()
		{
			if (_contentPresenter != null)
			{
				var item = SelectedItem is ComboBoxItem cbi ? cbi.Content : SelectedItem;
				_contentPresenter.Content = item;
			}
		}

		protected override void OnIsEnabledChanged(bool oldValue, bool newValue)
		{
			base.OnIsEnabledChanged(oldValue, newValue);

			UpdateCommonStates();

			OnIsEnabledChangedPartial(oldValue, newValue);
		}

		partial void OnIsEnabledChangedPartial(bool oldValue, bool newValue);

		partial void OnIsDropDownOpenChangedPartial(bool oldIsDropDownOpen, bool newIsDropDownOpen)
		{
			if (_popup != null)
			{
				_popup.IsOpen = newIsDropDownOpen;
			}

			if (newIsDropDownOpen)
			{
				DropDownOpened?.Invoke(this, newIsDropDownOpen);
			}
			else
			{
				DropDownClosed?.Invoke(this, newIsDropDownOpen);
			}

			UpdateDropDownState();
		}

		protected override void OnPointerReleased(PointerRoutedEventArgs e)
		{
			IsDropDownOpen = true;
		}

		// This is required by some apps trying to emulate the native iPhone look for ComboBox. 
		// The standard popup layouter works like on Windows, and doesn't stretch to take the full size of the screen.
		public bool IsPopupFullscreen { get; set; } = false;

		private void UpdateDropDownState()
		{
			var state = IsDropDownOpen ? "Opened" : "Closed";
			VisualStateManager.GoToState(this, state, true);
		}

		private void UpdateCommonStates()
		{
			var state = IsEnabled ? "Normal" : "Disabled";
			VisualStateManager.GoToState(this, state, true);
		}

		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new ComboBoxAutomationPeer(this);
		}

		private class DropDownLayouter : PopupBase.IDynamicPopupLayouter
		{
			private readonly ComboBox _combo;
			private readonly PopupBase _popup;

			public DropDownLayouter(ComboBox combo, PopupBase popup)
			{
				_combo = combo;
				_popup = popup;
			}

			/// <inheritdoc />
			public Size Measure(Size available, Size visibleSize)
			{
				if (!(_popup.Child is FrameworkElement child))
				{
					return new Size();
				}

				// Inject layouting constraints
				// Note: Even if this is ugly (as we should never alter properties of a random child like this),
				//		 it's how UWP behaves (but it does that only if the child is a Border, otherwise everything is messed up).
				//		 It sets (at least) those properties :
				//			MinWidth
				//			MinHeight
				//			MaxWidth
				//			MaxHeight

				if (_combo.IsPopupFullscreen)
				{
					// Size : Note we set both Min and Max to match the UWP behavior which alter only those properties
					child.MinWidth = available.Width;
					child.MinHeight = available.Height;
					child.MaxWidth = available.Width;
					child.MaxHeight = available.Height;
				}
				else
				{
					// Set the popup child as max 9 x the height of the combo
					// (UWP seams to actually limiting to 9 visible items ... which is not necessarily the 9 x the combo height)
					var maxHeight = Math.Min(visibleSize.Height, Math.Min(_combo.MaxDropDownHeight, _combo.ActualHeight * _itemsToShow));

					child.MinHeight = _combo.ActualHeight;
					child.MinWidth = _combo.ActualWidth;
					child.MaxHeight = maxHeight;
					child.MaxWidth = visibleSize.Width;
				}

				child.Measure(visibleSize);

				return child.DesiredSize;
			}

			private const int _itemsToShow = 9;

			/// <inheritdoc />
			public void Arrange(Size finalSize, Rect visibleBounds, Size desiredSize)
			{
				if (!(_popup.Child is FrameworkElement child))
				{
					return;
				}

				if (_combo.IsPopupFullscreen)
				{
					child.Arrange(new Rect(new Point(), finalSize));

					return;
				}

				var comboRect = _combo.GetAbsoluteBoundsRect();
				var frame = new Rect(comboRect.Location, desiredSize.AtMost(visibleBounds.Size));

				// On windows, the popup is Y-aligned accordingly to the selected item in order to keep
				// the selected at the same place no matter if the drop down is open or not.
				// For instance if selected is:
				//  * the first option: The drop-down appears below the combobox
				//  * the last option: The dop-down appears above the combobox
				// However this would requires us to determine the actual location of the SelectedItem container's
				// which might not be ready at this point (we could try a 2-pass arrange), and to scroll into view to make it visible.
				// So for now we only rely on the SelectedIndex and make a highly improvable vertical alignment based on it.

				var itemsCount = _combo.NumberOfItems;
				var selectedIndex = _combo.SelectedIndex;
				if (selectedIndex < 0 && itemsCount > 0)
				{
					selectedIndex = itemsCount / 2;
				}

				var stickyThreshold = Math.Max(1, Math.Min(4, (itemsCount / 2) - 1));
				if (selectedIndex >= 0 && selectedIndex < stickyThreshold)
				{
					// Try to appear below
					frame.Y = comboRect.Top;
				}
				else if (selectedIndex >= 0 && selectedIndex >= itemsCount - stickyThreshold
					// As we don't scroll into view to the selected item, this case seems awkward if the selected item
					// is not directly visible (i.e. without scrolling) when the drop-down appears.
					// So if we detect that we should had to scroll to make it visible, we don't try to appear above!
					&& (itemsCount <= _itemsToShow && frame.Height < (_combo.ActualHeight * _itemsToShow) - 3))
				{
					// Try to appear above
					frame.Y = comboRect.Bottom - frame.Height;
				}
				else
				{
					// Try to appear centered
					frame.Y = comboRect.Top - (frame.Height / 2.0) + (comboRect.Height / 2.0);
				}

				// Make sure that the popup does not appears out of the viewport
				if (frame.Left < visibleBounds.Left)
				{
					frame.X = visibleBounds.X;
				}
				else if (frame.Right > visibleBounds.Width)
				{
					// On UWP, the popup is just aligned to the right on the window if it overflows on right
					// Note: frame.Width is already at most visibleBounds.Width
					frame.X = visibleBounds.Width - frame.Width;
				}
				if (frame.Top < visibleBounds.Top)
				{
					frame.Y = visibleBounds.Y;
				}
				else if (frame.Bottom > visibleBounds.Height)
				{
					// On UWP, the popup always let 1 px free at the bottom
					// Note: frame.Height is already at most visibleBounds.Height
					frame.Y = visibleBounds.Height - frame.Height - 1; 
				}

				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Layout the combo's dropdown at {frame} (desired: {desiredSize} / available: {finalSize} / visible: {visibleBounds} / selected: {selectedIndex} of {itemsCount})");
				}

				child.Arrange(frame);
			}
		}
	}
}
