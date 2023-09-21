using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using aspCMS.Data;
using aspCMS.Models;
using System.Linq.Expressions;
using aspCMS.Repository;

namespace aspCMS.Repository.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDBContext _db;
        public CategoryRepository(AppDBContext db) : base(db)
        {
            _db = db;
        } 

        public Category GetCategoryByName(string categoryName)
        {
            return dbSet.Where(category => category.CategoryName == categoryName).FirstOrDefault();
        }

        public void EditCategory(Category newCategory)
        {
            dbSet.Update(newCategory);
        }

         }
}