using Challenge_KCMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_KCMS.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        // Obtem todos as categorias
        List<Category> GetCategories();

        // Adiciona categoria
        void InsertCategory(Category category);

        // Deleta categoria
        void DeleteCategory(int categoryId);

        // Deleta todas categorias
        void DeleteAllCategories();
    }
}
