using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{   

    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Category> AllCategories => appDBContext.Category;
    }
}
