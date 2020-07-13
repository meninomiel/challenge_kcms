using Challenge_KCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge_KCMS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProductPage : ContentPage
	{
		public AddProductPage ()
		{
			InitializeComponent ();
            BindingContext = new AddProductViewModel();
		}
	}
}