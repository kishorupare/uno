﻿using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Core;
using Uno.UI.Samples.UITests.Helpers;

namespace Uno.UI.Samples.Presentation.SamplePages
{
	public class ListViewSelectionsViewModel : ViewModelBase
	{
		private string _selectedName = "";

		public ListViewSelectionsViewModel(CoreDispatcher dispatcher) : base(dispatcher)
		{
			ClearSelection = CreateCommand(ExecuteClearSelection);
		}

		public string SelectedName
		{
			get => _selectedName;
			set
			{
				_selectedName = value;
				RaisePropertyChanged();
			}
		}

		public ICommand ClearSelection { get; }

		private void ExecuteClearSelection()
		{
			SelectedName = "";
		}

		private string[] GetSampleNames()
		{
			return new[]
			{
				"Keith",
				"Allison",
				"Iris",
				"Michelle",
				"Isidore",
				"Lili",
				"Fabian",
				"Isabel",
				"Juan",
				"Charley",
				"Frances",
				"Ivan",
				"Jeanne",
				"Dennis",
				"Katrina",
				"Rita",
				"Stan",
				"Wilma",
				"Dean",
				"Felix",
				"Noel",
				"Gustav",
				"Ike",
				"Paloma"
			};
		}

		public List<TwoLevelListItem> TwoLevelsItemList
		{
			get
			{
				return new List<TwoLevelListItem>
				{
					new TwoLevelListItem { SubLevelItems = new List<string> { "1a", "1b" } },
					new TwoLevelListItem { SubLevelItems = new List<string> { "2a", "2b", "2c" } }
				};
			}
		}
	}
}
