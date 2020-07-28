using Challenge_KCMS.ViewModels;
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