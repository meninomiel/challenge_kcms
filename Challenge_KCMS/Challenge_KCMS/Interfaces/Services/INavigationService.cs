using System.Threading.Tasks;

namespace Challenge_KCMS.Interfaces.Services
{
    public interface INavigationService
    {
        Task NavigateToAddProductPage();
        Task NavigateToProductDetailsPage(int id);
        Task NavigateToProductsPage();
        void PopAsyncService();
    }
}
