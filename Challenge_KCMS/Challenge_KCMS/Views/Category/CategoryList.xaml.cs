using Challenge_KCMS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge_KCMS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryList : ContentPage
	{
		public CategoryList()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            this.BindingContext = new CategoryListViewModel();
        }
    }
}