﻿using Challenge_KCMS.Models;
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
        void DeleteCategory(Category category);

        // Deleta todas categorias
        void DeleteAllCategories();

        // Obtem detalhe da categoria
        Category GetCategoryDetail(int categoryId);

        // Atualiza a categoria
        void UpdateCategory(Category category);
    }
}
