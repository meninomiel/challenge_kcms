using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
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
            Products = new ObservableCollection<Product>()
            {
                new Product()
                {
                    ProductID = 1,
                    Name = "Produto Um",
                    Description = "Descrição do produto.",
                    Price = 9.99,
                    Quantity = 1,
                    Image = "https://nicefilms.com.br/wp-content/uploads/ICON_PRODUTO.png"
                },
                new Product()
                {
                    ProductID = 2,
                    Name = "Produto Dois",
                    Description = "Descrição do produto.",
                    Price = 9.99,
                    Quantity = 2,
                    Image = "https://nicefilms.com.br/wp-content/uploads/ICON_PRODUTO.png"
                }
            };
            
            

            //this.Navigation = navigation;          
        }


        public ICommand ButtonAddProductCommand => new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());
        });
    }
}
