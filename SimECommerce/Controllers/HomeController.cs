using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimECommerce.Models;
using SimECommerce.ViewModels.HomeViewModel;

namespace SimECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ECommerceSimplifieContext _context;
        //public const string SessionPanier = "_Panier";
        

        public HomeController(ECommerceSimplifieContext context)
        {
            _context = context;
          
        }

        


        public  IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();
            IndexViewModel.Categories= _context.Category.ToList();
            IndexViewModel.Products = _context.Product.ToList();
            indexViewModel.CategorieParents = IndexViewModel.Categories.Where(c => c.ParentCategoryId == 0).ToList();
            indexViewModel.CategoriesHomePageList = IndexViewModel.Categories.Where(c => c.ShowOnHomePage == true).ToList();
           
            indexViewModel.ProductHomePageList = IndexViewModel.Products.Where(p => p.ShowOnHomePage == true).ToList();
            ViewBag.parentcategories = indexViewModel.CategorieParents;
            return View(indexViewModel);
        }

        //public IActionResult MenuCategories()
        //{
        //    IndexViewModel indexViewModel = new IndexViewModel();
        //    if (indexViewModel.CategorieParents.Count==0)
        //    {
        //        indexViewModel.CategorieParents = IndexViewModel.Categories.Where(c => c.ParentCategoryId == 0).ToList();
        //    }

        //    return PartialView("_NavigationCategories", indexViewModel.CategorieParents);
        //}
        public IActionResult GethpCategoryById(int? id)
        {
            if (id==null)
            {
                return new BadRequestResult();
            }
            var SousCategoriesHomePages=IndexViewModel.Categories.Where(c => c.Id == id).ToList();
            return PartialView("_hpCategoryGrid",SousCategoriesHomePages);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
