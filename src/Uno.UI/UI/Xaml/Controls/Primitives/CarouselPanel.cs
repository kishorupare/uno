﻿#if !__WASM__
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls.Primitives
{
	public partial class CarouselPanel : StackPanel //TODO: VirtualizingPanel https://github.com/nventive/Uno/issues/1133
	{

		public CarouselPanel()
		{
		}
	}
}
#endif
