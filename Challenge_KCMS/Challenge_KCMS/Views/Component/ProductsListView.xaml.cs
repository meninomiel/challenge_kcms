using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge_KCMS.Views.Component
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductsListView : ContentView
	{
		public ProductsListView ()
		{
			InitializeComponent ();
		}
	}
}