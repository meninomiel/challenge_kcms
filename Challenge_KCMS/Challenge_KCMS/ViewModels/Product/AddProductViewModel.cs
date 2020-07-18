using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using Challenge_KCMS.Validators;
using FluentValidation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {
        public ICommand AddProductCommand { get; private set; }
        public ICommand ViewAllProductCommand { get; private set; }

        public AddProductViewModel()
        {
            _productValidator = new ProductValidator();
            _product = new Product();
            _productRepository = new ProductRepository();
            AddProductCommand = new Command(async () => await AddProduct());
            ViewAllProductCommand = new Command(async () => await ShowProductList());
        }


        async Task AddProduct()
        {
            var context = new ValidationContext<Product>(_product);
            var validationResult = _productValidator.Validate(context);

            if (validationResult.IsValid)
            {
                bool userResponse = await _messageService.ShowAsyncBool(
                    "Adicionar Produto",
                    "Deseja adicionar este produto?", 
                    "OK", "Cancelar");

                if (userResponse)
                {
                    _productRepository.InsertProduct(_product);
                    await _navigationService.NavigateToProductsPage();
                }
            }
            else
            {
                await _messageService.ShowAsync(
                    "Adicionar Produto", validationResult
                    .Errors[0].ErrorMessage, "OK");
            }
        }

        async Task ShowProductList()
        {
            await _navigationService.NavigateToProductsPage();
        }
        public bool IsViewAll => _productRepository.GetProductList().Count > 0 ? true : false;


    }
}
