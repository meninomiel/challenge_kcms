using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Challenge_KCMS.ViewModels;
using Challenge_KCMS.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Challenge_KCMS.ViewModels
{
    public class AddProductViewModel : ProductsViewModel
    {

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        async void AddProductAsync()
        {
            Product NewProduct = new Product()
            {
                Name = ProductName,
                Price = System.Convert.ToDouble(ProductPrice)
            };

            //await App.Database.SaveProductAsync(NewProduct);

            ProductName = "OK";
            //listView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        public ICommand AddProductCommand => new Command(AddProductAsync);

        
    }
}
