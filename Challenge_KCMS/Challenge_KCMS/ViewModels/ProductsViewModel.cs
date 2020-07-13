using System.Collections.ObjectModel;
using Challenge_KCMS.Models;
using Challenge_KCMS.ViewModels;

namespace Challenge_KCMS.ViewModels
{
    public class ProductsViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
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
        }
    }
}
