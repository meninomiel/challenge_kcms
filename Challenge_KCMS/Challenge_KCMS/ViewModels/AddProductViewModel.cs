using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Challenge_KCMS.ViewModels;
using Challenge_KCMS.Models;
using System.ComponentModel;

namespace Challenge_KCMS.ViewModels
{
    public class AddProductViewModel : ProductsViewModel
    {

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public void AddProduct()
        {
            Product NewProduct = new Product()
            {
                Name = ProductName,
                Price = System.Convert.ToDouble(ProductPrice)
            };

            //ProductsViewModel.Products.Add(NewProduct);
            Products.Add(NewProduct);
        }

        public ICommand AddProductCommand => new Command(AddProduct);

        
    }
}
