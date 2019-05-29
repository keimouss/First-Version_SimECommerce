using SimECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ViewModels.CategoryVM
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Category category)
        {
            Category = category;
            CategorieList = new List<Category>();
        }

        public string NameCategorie { get; set; }
        public string NamePictureCategorie { get; set; }
        public int PictureIdCategorie { get; set; }

        List<Category> CategorieList { get; set; }
      public Category Category { get; set; }
    }
}
