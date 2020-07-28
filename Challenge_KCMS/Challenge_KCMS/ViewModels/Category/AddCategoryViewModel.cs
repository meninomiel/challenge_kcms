using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using Challenge_KCMS.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class AddCategoryViewModel : BaseViewModel
    {
        public ICommand AddCategoryCommand { get; private set; }

        public AddCategoryViewModel()
        {
            _categoryValidator = new CategoryValidator();
            _category = new Category();
            _categoryRepository = new CategoryRepository();

            AddCategoryCommand = new Command(async () => await AddCategory());
        }

        async Task AddCategory()
        {
            var context = new ValidationContext<Category>(_category);
            var validationResult = _categoryValidator.Validate(context);

            if (validationResult.IsValid)
            {
                bool userResponse = await _messageService.ShowAsyncBool(
                    "Adicionar Categoria",
                    "Deseja Adicionar esta categoria?",
                    "Sim","Cancelar");

                if (userResponse)
                {
                    _categoryRepository.InsertCategory(_category);
                    _navigationService.PopAsyncService();
                }
            }
            else
            {
                await _messageService.ShowAsync(
                    "Adicionar Categoria",
                    validationResult.Errors[0].ErrorMessage,
                    "OK");
            }
        }
    }
}
