using Challenge_KCMS.Models;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_KCMS.Data
{
    public class DatabaseHelper
    {
        // Definindo uma conexao e o nome do banco de dados
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "StoreDB.db";

        public DatabaseHelper()
        {
            // Criando uma pasta base local para o dispositivo
            var folder = new LocalRootFolder();

            // Criando o arquivo
            var file = folder.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);

            // Abrindo o Base de Dados
            sqliteconnection = new SQLiteConnection(file.Path);

            // Criando a tabela no BD
            sqliteconnection.CreateTable<Product>();
            sqliteconnection.CreateTable<Category>();
        }

        #region CRUD PRoduct Methods

        // Obter todos os produtos  
        public List<Product> GetProductList()
        {
            return (from data in sqliteconnection.Table<Product>()
                    select data).ToList();
        }

        // Obter detalhes do produto
        public Product GetProductDetail(int id)
        {
            return sqliteconnection.Table<Product>().FirstOrDefault(t => t.Id == id);
        }

        // Adicionar Produto
        public void InsertProduct(Product product)
        {
            sqliteconnection.Insert(product);
        }

        // Atualizar Produto
        public void UpdateProduct(Product product)
        {
            sqliteconnection.Update(product);
        }

        // Deletar produto
        public void DeleteProduct(int id)
        {
            sqliteconnection.Delete<Product>(id);
        }

        // Deletar tudo
        public void DeleteAllProducts()
        {
            sqliteconnection.DeleteAll<Product>();
        }

        #endregion

        #region CRUD Category Methods

        // Obter todas as categorias
        public List<Category> GetCategories()
        {
            return (from data in sqliteconnection.Table<Category>()
                    select data).ToList();
        }

        // Adicionar categoria
        public void InsertCategory(Category category)
        {
            sqliteconnection.Insert(category);
        }

        // Obter detalhes da categoria
        public Category GetCategoryDetail(int categoryId)
        {
            return sqliteconnection.Table<Category>().FirstOrDefault(t => t.Id == categoryId);
        }

        // Deletar categoria
        public void DeleteCategory(int categoryId)
        {
            sqliteconnection.Delete<Category>(categoryId);
        }

        // Deletar tudo
        public void DeleteAllCategories()
        {
            sqliteconnection.DeleteAll<Category>();
        }

        // Atualizar categoria
        public void UpdateCategory(Category category)
        {
            sqliteconnection.Update(category);
        }

        #endregion
    }
}
