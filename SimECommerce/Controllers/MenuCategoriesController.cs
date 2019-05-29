using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimECommerce.Models;
using SimECommerce.ViewModels.HomeViewModel;
using SimECommerce.ViewModels.MenuViewModel;

namespace SimECommerce.Controllers
{
    public class MenuCategoriesController : Controller
    {
        private readonly ECommerceSimplifieContext _context;
        public MenuCategoriesController(ECommerceSimplifieContext context)
        {
            _context = context;
        }
        public IActionResult NavigationCategories()
        {
           
            
            var pCategories = _context.Category.Where(c => c.Id == 0).ToList();
            //IList menuViewModel = new List();

            //foreach (var categories in pCategories)
            //{
            //    CategoryMenuViewModel menu = new CategoryMenuViewModel() {CategoryMenuID=categories.Id, Title=categories.Name };
            //    menuViewModel.Add(menu);
            //}


            return PartialView();
        }
    }
}