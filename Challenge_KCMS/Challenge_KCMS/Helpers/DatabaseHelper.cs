using Challenge_KCMS.Models;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using SQLiteNetExtensions.Extensions;

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


        #region CRUD Product Methods

        // Obter todos os produtos  
        public List<Product> GetProductList()
        {
            // using SQLite Extensions to solve relations
            return ReadOperations.GetAllWithChildren<Product>(sqliteconnection);
        }

        // Obter detalhes do produto
        public Product GetProductDetail(int id)
        {
            return ReadOperations.GetWithChildren<Product>(sqliteconnection, id);
        }

        // Adicionar Produto
        public void InsertProduct(Product product)
        {
            WriteOperations.InsertWithChildren(sqliteconnection, product);
        }

        // Atualizar Produto
        public void UpdateProduct(Product product)
        {
            WriteOperations.UpdateWithChildren(sqliteconnection, product);
        }

        // Deletar produto
        public void DeleteProduct(int id)
        {
            WriteOperations.Delete(sqliteconnection, id, false);
        }

        // Deletar tudo
        public void DeleteAllProducts()
        {
            List<Product> products = GetProductList();
            WriteOperations.DeleteAll(sqliteconnection, products);
        }

        #endregion

        #region CRUD Category Methods

        // Obter todas as categorias
        public List<Category> GetCategories()
        {
            return ReadOperations.GetAllWithChildren<Category>(sqliteconnection);
        }

        // Adicionar categoria
        public void InsertCategory(Category category)
        {
            WriteOperations.InsertWithChildren(sqliteconnection, category);
        }

        // Obter detalhes da categoria
        public Category GetCategoryDetail(int categoryId)
        {
            return ReadOperations.GetWithChildren<Category>(sqliteconnection, categoryId);
        }

        // Deletar categoria
        public void DeleteCategory(int categoryId)
        {
            WriteOperations.Delete(sqliteconnection, categoryId, false);
        }

        // Deletar tudo
        public void DeleteAllCategories()
        {
            List<Category> categories = GetCategories();
            WriteOperations.DeleteAll(sqliteconnection, categories);
        }

        // Atualizar categoria
        public void UpdateCategory(Category category)
        {
            WriteOperations.UpdateWithChildren(sqliteconnection, category);
        }

        #endregion
    }
}
