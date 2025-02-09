using System.Threading;
using System.Threading.Tasks;
using Uno.UI.Samples.Controls;
using Uno.UI.Samples.Helper;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Samples.Content.UITests.GridTestsControl
{
	[SampleControlInfoAttribute("DefaultCategory", "Grid_DataBound_ColumnRow_Definitions")]
	public sealed partial class Grid_DataBound_ColumnRow_Definitions : UserControl
	{
		private Grid_DataBound_ColumnRow_Definitions_Context _context;

		public Grid_DataBound_ColumnRow_Definitions()
		{
			this.InitializeComponent();

			this.RunWhileLoaded(Run);
		}

		private async Task Run(CancellationToken ct)
		{
			await Task.Yield();

			var toggle = false;

			DataContext = _context = new Grid_DataBound_ColumnRow_Definitions_Context();

			while(!ct.IsCancellationRequested)
			{
				if(!toggle)
				{
					_context.Value1 = 42;
					_context.Value2 = 12;
				}
				else
				{
					_context.Value1 = 12;
					_context.Value2 = 42;
				}

				toggle = !toggle;

				await Task.Delay(1000);
			}
		}
	}

	public partial class Grid_DataBound_ColumnRow_Definitions_Context : DependencyObject
	{
		public Grid_DataBound_ColumnRow_Definitions_Context()
		{
		}

		#region Value1 DependencyProperty

		public int Value1
		{
			get => (int)GetValue(Value1Property);
			set => SetValue(Value1Property, value);
		}

		// Using a DependencyProperty as the backing store for Value1.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty Value1Property =
			DependencyProperty.Register("Value1", typeof(int), typeof(Grid_DataBound_ColumnRow_Definitions_Context), new PropertyMetadata(0));

		#endregion

		public int Value2
		{
			get => (int)GetValue(Value2Property);
			set => SetValue(Value2Property, value);
		}

		// Using a DependencyProperty as the backing store for Value2.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty Value2Property =
			DependencyProperty.Register("Value2", typeof(int), typeof(Grid_DataBound_ColumnRow_Definitions_Context), new PropertyMetadata(0));

	}
}
