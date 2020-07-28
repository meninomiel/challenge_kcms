using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using Challenge_KCMS.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    class CategoryDetailsViewModel : BaseViewModel
    {
        public ICommand UpdateCategoryCommand { get; private set; }
        public ICommand DeleteCategoryCommand { get; private set; }

        public CategoryDetailsViewModel(int selectedCategoryId)
        {
            _categoryValidator = new CategoryValidator();
            _category = new Category()
            {
                Id = selectedCategoryId
            };
            _categoryRepository = new CategoryRepository();

            UpdateCategoryCommand = new Command(async () => await UpdateCategory());
            DeleteCategoryCommand = new Command(async () => await DeleteCategory());

            FetchCategoryDetails();
            GetAllProducts();
        }

        void FetchCategoryDetails()
        {
            _category = _categoryRepository.GetCategoryDetail(_category.Id);
        }

        void GetAllProducts()
        {
            ProductList = _category.Products;
        }

        async Task DeleteCategory()
        {
            bool userResponse = await _messageService.ShowAsyncBool(
                "Deletar Categoria",
                "Tem certeza que quer deletar a categoria?",
                "Sim", "Cancelar");

            if (userResponse)
            {
                _categoryRepository.DeleteCategory(_category);
                _navigationService.PopAsyncService();
            }
        }

        async Task UpdateCategory()
        {
            var context = new ValidationContext<Category>(_category);
            var validationResult = _categoryValidator.Validate(context);

            if (validationResult.IsValid)
            {
                bool isUserAccept = await _messageService.ShowAsyncBool(
                    "Atualizar Categoria",
                    "Tem certeza que quer modificar a categoria?",
                    "Sim", "Cancelar");

                if (isUserAccept)
                {
                    _categoryRepository.UpdateCategory(_category);
                    await _navigationService.NavigateToCategoriesPage();
                }
            }
            else
            {
                await _messageService.ShowAsync(
                    "Detalhes da Categoria",
                    validationResult.Errors[0].ErrorMessage, "OK");
            }
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
    }
}
