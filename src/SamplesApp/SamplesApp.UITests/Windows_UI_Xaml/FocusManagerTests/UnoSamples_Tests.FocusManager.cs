using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.Windows_UI_Xaml_Controls.FocusManagerTests
{
	[TestFixture]
	public partial class FocusManagerTests_Tests : SampleControlUITestBase
	{
		[Test]
		public void FocusManager_GetFocusedElement_Border_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyBorder");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Border - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Border - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_Button_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Button - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyButton", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Button - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_Button_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - Button - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - Button - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_CheckBox_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyCheckBox");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - CheckBox - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyCheckBox", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - CheckBox - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_CheckBox_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyCheckBox");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - CheckBox - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - CheckBox - 3 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_Grid_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyGrid");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Grid - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Grid - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_HyperlinkButton_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("HyperlinkButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - HyperlinkButton - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - HyperlinkButton - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_HyperlinkButton_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("HyperlinkButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - HyperlinkButton - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - HyperlinkButton - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_Image_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyImage");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Image - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Image - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_Rectangle_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyRectangle");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Rectangle - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - Rectangle - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_TextBlock_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyTextBlock");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBlock - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBlock - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_TextBoxMultiLine_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("TextBoxMultiLine");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBoxMultiLine - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("TextBoxMultiLine", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBoxMultiLine - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_TextBoxMultiLine_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("TextBoxMultiLine");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - TextBoxMultiLine - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - TextBoxMultiLine - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_TextBoxSingleLine_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("TextBoxSingleLine");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBoxSingleLine - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("TextBoxSingleLine", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - TextBoxSingleLine - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_TextBoxSingleLine_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("TextBoxSingleLine");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - TextBoxSingleLine - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - TextBoxSingleLine - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ToggleButton_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyToggleButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ToggleButton - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyToggleButton", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ToggleButton - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ToggleButton_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyToggleButton");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ToggleButton - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ToggleButton - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ComboBox_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyComboBox");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ComboBox - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyComboBox", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ComboBox - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ComboBox_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var frameworkElement = _app.Marked("MyComboBox");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ComboBox - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ComboBox - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ComboBoxItem_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var comboBox = _app.Marked("MyComboBox");
			var frameworkElement = _app.Marked("MyComboBoxItem_1");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ComboBoxItem - 1 - Inital State");

			comboBox.Tap();
			_app.Wait(2);

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyComboBoxItem_1", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ComboBoxItem - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ComboBoxItem_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var comboBox = _app.Marked("MyComboBox");
			var frameworkElement = _app.Marked("MyComboBoxItem_1");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ComboBoxItem - 1 - Inital State");

			comboBox.Tap();
			_app.Wait(2);

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ComboBoxItem - 2 - Click outside");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ScrollViewer_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var scrollViewer = _app.Marked("ScrollViewer");
			var frameworkElement = _app.Marked("MyScrollViewerElement");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ScrollViewer - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ScrollViewer - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ListViewItem_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var listView = _app.Marked("MyListView");
			var frameworkElement = _app.Marked("MyListViewItem");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ListViewItem - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			// Assert After Selection 
			Assert.AreEqual("MyListViewItem", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - GetFocusedElement - ListViewItem - 2 - After Selection");
		}

		[Test]
		public void FocusManager_GetFocusedElement_ListViewItem_LostFocus_Validation()
		{
			Run("Uno.UI.Samples.Content.UITests.FocusManager.FocusManager_GetFocus_Automated");

			_app.WaitForElement(_app.Marked("TxtCurrentFocused"));

			var txtCurrentFocused = _app.Marked("TxtCurrentFocused");
			var listView = _app.Marked("MyListView");
			var frameworkElement = _app.Marked("MyListViewItem");

			_app.Tap(txtCurrentFocused);

			// Assert inital state 
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ListViewItem - 1 - Inital State");

			frameworkElement.Tap();
			_app.Wait(2);

			_app.TapCoordinates(20, 100);
			_app.Wait(2);

			// Assert Click outside
			Assert.AreEqual("", txtCurrentFocused.GetDependencyPropertyValue("Text")?.ToString());
			_app.Screenshot("FocusManager - LostFocus - ListViewItem - 2 - Click outside");
		}

		[Test]
		public void TimePickerFlyout_DiscardChanges()
		{
			Run("Uno.UI.Samples.Content.UITests.TimePicker.TimePicker_Automated");

			_app.WaitForElement(_app.Marked("btnApplyNewTime"));

			var txtSelectedTime = _app.Marked("txtSelectedTime");
			var myTimePicker = _app.Marked("myTimePicker");

			// Assert inital state 
			Assert.AreEqual("14:50", txtSelectedTime.GetDependencyPropertyValue("Text")?.ToString());
			Assert.AreEqual("14:50:00", myTimePicker.GetDependencyPropertyValue("Time")?.ToString());

			_app.SetOrientationPortrait();

			// Open and dismiss flyout
			myTimePicker.Tap();
			var myDevice = _app.Device.GetType();
			if (_app.Device.GetType().Name.Contains("Android"))
			{
				_app.TapCoordinates(988, 1625);
				_app.Wait(2);
				_app.TapCoordinates(988, 1625);

				_app.Find("Cancel").Tap();
				_app.Wait(2);
			}
			else
			{
				// To do Task Number: - 155260 complete test case for IOS.
			}
			//Assert final state
			Assert.AreEqual("14:50", txtSelectedTime.GetDependencyPropertyValue("Text")?.ToString());
			Assert.AreEqual("14:50:00", myTimePicker.GetDependencyPropertyValue("Time")?.ToString());
		}

		[Test]
		public void TimePickerFlyout_ApplyChanges()
		{
			Run("Uno.UI.Samples.Content.UITests.TimePicker.TimePicker_Automated");

			_app.WaitForElement(_app.Marked("btnApplyNewTime"));

			var txtSelectedTime = _app.Marked("txtSelectedTime");
			var myTimePicker = _app.Marked("myTimePicker");

			// Assert inital state 
			Assert.AreEqual("14:50", txtSelectedTime.GetDependencyPropertyValue("Text")?.ToString());
			Assert.AreEqual("14:50:00", myTimePicker.GetDependencyPropertyValue("Time")?.ToString());

			_app.SetOrientationPortrait();

			// Open, change ime and click on ok to apply changes and to close flyout
			myTimePicker.Tap();
			var myDevice = _app.Device.GetType();
			if (_app.Device.GetType().Name.Contains("Android"))
			{
				_app.TapCoordinates(988, 1625);
				_app.Wait(2);
				_app.TapCoordinates(988, 1625);

				_app.Find("OK").Tap();
				_app.Wait(2);

				//Assert final state
				Assert.AreNotEqual("14:50", txtSelectedTime.GetDependencyPropertyValue("Text")?.ToString());
				Assert.AreNotEqual("14:50:00", myTimePicker.GetDependencyPropertyValue("Time")?.ToString());
			}
			else
			{
				// To do Task Number: - 155260 complete test case for IOS.KD
			}
		}
	}
}
