using System;
using System.Collections.Generic;

using aspCMS.Models;

namespace aspCMS.Repository.CategoryRepository

{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Category GetCategoryByName(string categoryName);

        public void EditCategory(Category newCategory);
    }
}