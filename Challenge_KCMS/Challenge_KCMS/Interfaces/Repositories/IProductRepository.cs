using Challenge_KCMS.Models;
using System.Collections.Generic;

namespace Challenge_KCMS.Services
{
    public interface IProductRepository
    {
        // Obtem todos os produtos 
        List<Product> GetProductList();

        // Obter detalhes do produto
        Product GetProductDetail(int productId);

        // Adiciona um Produto
        void InsertProduct(Product product);

        // Atualiza um Produto
        void UpdateProduct(Product product);

        // Deleta um produto
        void DeleteProduct(Product product);

        // Deleta um tudo
        void DeleteAllProducts();
    }
}
