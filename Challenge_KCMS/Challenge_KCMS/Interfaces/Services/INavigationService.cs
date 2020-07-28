using System.Threading.Tasks;

namespace Challenge_KCMS.Interfaces.Services
{
    public interface INavigationService
    {
        Task NavigateToAddProductPage();
        Task NavigateToProductDetailsPage(int productId);
        Task NavigateToProductsPage();

        Task NavigateToAddCategoryPage();
        Task NavigateToCategoryDetailPage(int categoryId);
        Task NavigateToCategoriesPage();
        void PopAsyncService();
    }
}
