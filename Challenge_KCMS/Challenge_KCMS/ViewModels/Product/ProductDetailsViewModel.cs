using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using Challenge_KCMS.Validators;
using Challenge_KCMS.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public ICommand UpdateProductCommand { get; private set; }
        public ICommand DeleteProductCommand { get; private set; }

        public ProductDetailsViewModel(int selectedProductId)
        {
            _productValidator = new ProductValidator();
            _product = new Product
            {
                Id = selectedProductId
            };
            _productRepository = new ProductRepository();
            UpdateProductCommand = new Command(async () => await UpdateProduct());
            DeleteProductCommand = new Command(async () => await DeleteProduct());

            FetchProductDetails();

        }

        async Task DeleteProduct()
        {
            bool userResponse = await _messageService.ShowAsyncBool(
                "Deletar Produto",
                "Tem certeza que quer deletar o produto?", 
                "OK", "Cancelar");
            if (userResponse)
            {
                _productRepository.DeleteProduct(_product.Id);
                _navigationService.PopAsyncService();
            }
        }

        async Task UpdateProduct()
        {
            var context = new ValidationContext<Product>(_product);
            var validateResult = _productValidator.Validate(context);

            if (validateResult.IsValid)
            {
                bool isUserAccept = await _messageService.ShowAsyncBool(
                    "Atualização de Produto",
                    "Tem certeza que quer modificar o produto?", 
                    "OK", "Cancelar");

                if (isUserAccept)
                {
                    _productRepository.UpdateProduct(_product);
                    _navigationService.PopAsyncService();
                }
            }
            else
            {
                await _messageService.ShowAsync(
                    "Detalhes do Pedido", validateResult
                    .Errors[0].ErrorMessage, "OK");
            }
        }

        void FetchProductDetails()
        {
            _product = _productRepository.GetProductDetail(_product.Id);
        }



    }
}
