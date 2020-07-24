using System.Collections.Generic;
using Challenge_KCMS.Data;
using Challenge_KCMS.Models;

namespace Challenge_KCMS.Services
{
    class ProductRepository : IProductRepository
    {
        DatabaseHelper _databaseHelper;
        public ProductRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteAllProducts()
        {
            _databaseHelper.DeleteAllProducts();
        }

        public void DeleteProduct(Product product)
        {
            _databaseHelper.DeleteProduct(product);
        }

        public Product GetProductDetail(int productId)
        {
            return _databaseHelper.GetProductDetail(productId);
        }

        public List<Product> GetProductList()
        {
            return _databaseHelper.GetProductList();
        }

        public void InsertProduct(Product product)
        {
            _databaseHelper.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _databaseHelper.UpdateProduct(product);
        }
    }
}
