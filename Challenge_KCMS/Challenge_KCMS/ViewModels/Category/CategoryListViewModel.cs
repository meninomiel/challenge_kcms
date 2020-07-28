using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class CategoryListViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllCategoriesCommand { get; private set; }
        public ICommand GoToAddProductCommand { get; private set; }
        public ICommand GoToProductListPageCommand { get; private set; }

        public CategoryListViewModel()
        {
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();

            AddCommand = new Command(async () => await GoToAddCategoryPage());
            DeleteAllCategoriesCommand = new Command(async () => await DeleteAllCategories());
            GoToAddProductCommand = new Command(async () => await GoToAddProductPage());
            GoToProductListPageCommand = new Command(async () => await GoToProductListPage());

            GetAllCategories();
        }

        async Task GoToProductListPage()
        {
            await _navigationService.NavigateToProductsPage();
        }

        async Task GoToAddProductPage()
        {
            await _navigationService.NavigateToAddProductPage();
        }

        private void GetAllCategories()
        {
            CategoryList = _categoryRepository.GetCategories();
        }

        async Task DeleteAllCategories()
        {
            bool userResponse = await _messageService.ShowAsyncBool(
                "Deletar todas as categorias",
                "Tem certeza que quer fazer esta operação?",
                "Sim", "Cancelar");

            if (userResponse)
            {
                _categoryRepository.DeleteAllCategories();
                await _navigationService.NavigateToAddCategoryPage();
            }
        }

        async Task GoToAddCategoryPage()
        {
            await _navigationService.NavigateToAddCategoryPage();
        }

        async void ShowCategoryDetails(int selectedCategory)
        {
            await _navigationService.NavigateToCategoryDetailPage(selectedCategory);
        }

        Category _selectedCategoryItem;
        public Category SelectedCategoryItem
        {
            get => _selectedCategoryItem;
            set
            {
                if (value != null)
                {
                    _selectedCategoryItem = value;
                    NotifyPropertyChanged("SelectedCategoryItem");
                    ShowCategoryDetails(value.Id);
                }
            }
        }

        public bool HasAnyProduct
        {
            get
            {
                int productCount = _productRepository.GetProductList().Count;
                return (productCount > 0) ? true : false;
            }
            set { }
        }

        public bool HasAnyCategory
        {
            get
            {
                int categoryCount = CategoryList.Count;
                return (categoryCount > 0) ? false : true;
            }
            set { }
        }
    }
}
