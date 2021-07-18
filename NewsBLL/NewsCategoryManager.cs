using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsDAL;
using NewsModels;

namespace NewsBLL
{
    public static class NewsCategoryManager
    {
        public static void DeleteNewsCategory(NewsCategory newCategory)
        {
            NewsCategoryService.DeleteNewsCategory(newCategory);
        }

        public static void ModifyNewsCategory(NewsCategory newCategory)
        {
            NewsCategoryService.ModifyNewsCategory(newCategory);
        }

        public static IList<NewsCategory> GetNewsCategories()
        {
            return NewsCategoryService.GetNewsCategories();
        }

        public static NewsCategory GetNewsCategoryById(int id)
        {
            return NewsCategoryService.GetNewsCategoryById(id);
        }
    }
}
