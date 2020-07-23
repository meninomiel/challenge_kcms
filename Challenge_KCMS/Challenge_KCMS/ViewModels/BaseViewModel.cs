using Challenge_KCMS.Interfaces.Repositories;
using Challenge_KCMS.Interfaces.Services;
using Challenge_KCMS.Models;
using Challenge_KCMS.Services;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Product _product;
        public IValidator _productValidator;
        public IProductRepository _productRepository;

        public Category _category;
        public IValidator _categoryValidator;
        public ICategoryRepository _categoryRepository;

        protected IMessageService _messageService;
        protected INavigationService _navigationService;

        public BaseViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        #region Properties

        #region Product
        public string Name
        {
            get => _product.Name;
            set
            {
                _product.Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _product.Description;
            set
            {
                _product.Description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        public decimal Price
        {
            get => _product.Price;
            set
            {
                _product.Price = value;
                NotifyPropertyChanged(nameof(Price));
            }
        }

        public Category Category
        {
            get => _product.Category;
            set
            {
                _product.Category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        List<Product> _productList;
        public List<Product> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                NotifyPropertyChanged(nameof(ProductList));
            }
        }

        #endregion

        #region Category

        public string CategoryName
        {
            get => _category.Name;
            set
            {
                _category.Name = value;
                NotifyPropertyChanged(nameof(CategoryName));
            }
        }

        List<Category> _categoryList;
        public List<Category> CategoryList
        {
            get => _categoryList;
            set
            {
                _categoryList = value;
                NotifyPropertyChanged(nameof(CategoryList));
            }
        }

        ICollection<Category> _productListOfCategory;
        public ICollection<Category> ProductListOfCategory
        {
            get => _productListOfCategory;
            set
            {
                _productListOfCategory = value;
                NotifyPropertyChanged(nameof(ProductListOfCategory));
            }
        }

        #endregion

        #endregion
        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        #endregion
    }
}
