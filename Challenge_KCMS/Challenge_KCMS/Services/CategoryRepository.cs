using Challenge_KCMS.Data;
using Challenge_KCMS.Interfaces.Repositories;
using Challenge_KCMS.Models;
using System;
using System.Collections.Generic;

namespace Challenge_KCMS.Services
{
    class CategoryRepository : ICategoryRepository
    {
        DatabaseHelper _databaseHelper;
        public CategoryRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteAllCategories()
        {
            _databaseHelper.DeleteAllCategories();
        }

        public void DeleteCategory(Category category)
        {
            _databaseHelper.DeleteCategory(category);
        }

        public List<Category> GetCategories()
        {
            return _databaseHelper.GetCategories();
        }

        public Category GetCategoryDetail(int categoryId)
        {
            return _databaseHelper.GetCategoryDetail(categoryId);
        }

        public void InsertCategory(Category category)
        {
            _databaseHelper.InsertCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _databaseHelper.UpdateCategory(category);
        }
    }
}
