using SimECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ViewModels.HomeViewModel
{
    public class IndexViewModel
    {
       
        public IndexViewModel()
        {
            Categories = new HashSet<Category>();
            CategorieParents = new HashSet<Category>();
            SousCategoriesHomePages = new HashSet<Category>();
            CategoriesHomePageList = new HashSet<Category>();
            ProductHomePageList = new HashSet<Product>();
        }

        public static ICollection<Category> Categories { get; set; }
        public static ICollection<Product> Products { get; set; }
        public ICollection<Category> CategorieParents { get; set; }
        public ICollection<Category> SousCategoriesHomePages { get; set; }
        public ICollection<Category> CategoriesHomePageList { get; set; }
        public ICollection<Product> ProductHomePageList { get; set; }
    }
}
