﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Uno.UI.Samples.Content.UITests.TextBoxControl
{
	[SampleControlInfoAttribute("TextBoxControl", "TextBox_TextProperty", typeof(Uno.UI.Samples.Presentation.SamplePages.TextBoxViewModel))]
	public sealed partial class TextBox_TextProperty : UserControl
    {
        public TextBox_TextProperty()
        {
            this.InitializeComponent();
        }
	}
}
