using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Challenge_KCMS.Data;
using Challenge_KCMS.Models;
using Challenge_KCMS.ViewModels;
using Challenge_KCMS.Views;
using Xamarin.Forms;

namespace Challenge_KCMS.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ProductsViewModel()
        {
                      
        }


        public ICommand ButtonAddProductCommand => new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());
        });
    }
}
