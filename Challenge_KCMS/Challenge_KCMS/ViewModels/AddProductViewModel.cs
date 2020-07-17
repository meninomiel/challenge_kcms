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

        void AddProductAsync()
        {
            ProductName = "";
        }

        public ICommand AddProductCommand => new Command(AddProductAsync);

        
    }
}
