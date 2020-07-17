using System.Threading.Tasks;
using Challenge_KCMS.Interfaces.Services;
using Challenge_KCMS.Views;

namespace Challenge_KCMS.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAddProductPage()
        {
            await Challenge_KCMS.App.Current.MainPage.Navigation.PushAsync(new AddProductPage());
        }

        public async Task NavigateToProductDetailsPage(int id)
        {
            await Challenge_KCMS.App.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage(id));
        }

        public async Task NavigateToProductsPage()
        {
            await Challenge_KCMS.App.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }

        public async void PopAsyncService()
        {
            await Challenge_KCMS.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
