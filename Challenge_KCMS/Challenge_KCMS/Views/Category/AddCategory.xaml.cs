using Challenge_KCMS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge_KCMS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCategory : ContentPage
	{
        public AddCategory ()
		{
			InitializeComponent();
            BindingContext = new AddCategoryViewModel();
        }
    }
}