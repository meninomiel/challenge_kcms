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
	public partial class ProductDetails : ContentPage
	{
		public ProductDetails(int productId)
		{
			InitializeComponent();
            this.BindingContext = new ProductDetailsViewModel(productId);
		}
	}
}