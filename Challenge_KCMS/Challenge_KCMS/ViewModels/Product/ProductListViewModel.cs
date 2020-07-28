using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Challenge_KCMS.Data;
using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using Challenge_KCMS.ViewModels;
using Challenge_KCMS.Views;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllProductsCommand { get; private set; }

        public ProductListViewModel()
        {
            _productRepository = new ProductRepository();

            AddCommand = new Command(async () => await GoToAddProductPage());
            DeleteAllProductsCommand = new Command(async () => await DeleteAllProducts());

            GetAllProducts();
        }

        void GetAllProducts()
        {
            ProductList = _productRepository.GetProductList();
        }

        async Task DeleteAllProducts()
        {
            bool userResponse = await _messageService.ShowAsyncBool(
                "Deletar todos os Produtos",
                "Tem certeza que quer fazer esta operação?", 
                "Sim", "Cancelar");

            if (userResponse)
            {
                _productRepository.DeleteAllProducts();
                await _navigationService.NavigateToAddProductPage();
            }
        }

        async Task GoToAddProductPage()
        {
            await _navigationService.NavigateToAddProductPage();
        }

        async void ShowProductDetails(int selectedProductId)
        {
            await _navigationService.NavigateToProductDetailsPage(selectedProductId);
        }

        Product _selectedProductItem;
        public Product SelectedProductItem
        {
            get => _selectedProductItem;
            set
            {
                if (value != null)
                {
                    _selectedProductItem = value;
                    NotifyPropertyChanged("SelectedProductItem");
                    ShowProductDetails(value.Id);
                }
            }
        }

        public bool HasAnyProduct
        {
            get
            {
                int productCount = ProductList.Count;
                return (productCount > 0) ? false : true;
            }
            set { }
        }

    }
}
