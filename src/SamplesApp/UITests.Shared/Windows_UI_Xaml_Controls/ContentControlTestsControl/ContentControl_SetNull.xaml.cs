using System;
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

namespace Uno.UI.Samples.Content.UITests.ContentControlTestsControl
{
	[SampleControlInfoAttribute("ContentControlTestsControl", "ContentControl_SetNull", typeof(Presentation.SamplePages.ContentControlTestViewModel))]
	public sealed partial class ContentControl_SetNull : UserControl
	{
		public ContentControl_SetNull()
		{
			this.InitializeComponent();
		}
	}
}
