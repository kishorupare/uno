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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Uno.UI.Samples.Content.UITests.ContentControlTestsControl
{
	[SampleControlInfoAttribute("ContentControlTestsControl", "ContentControl_NoTemplateDataContext")]
	public sealed partial class ContentControl_NoTemplateDataContext : UserControl
    {
        public ContentControl_NoTemplateDataContext()
        {
#if XAMARIN
			Style.RegisterDefaultStyleForType(typeof(MySelectorItem), StaticResources.SelectorItemStyle);
#endif

			this.InitializeComponent();
        }
    }

	public partial class MySelectorItem : SelectorItem
	{
		public MySelectorItem()
		{

		}
	}
}
