using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimECommerce.Models;

namespace SimECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceSimplifieContext _context;

        public ProductsController(ECommerceSimplifieContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductTypeId,ParentGroupedProductId,VisibleIndividually,Name,ShortDescription,FullDescription,AdminComment,ProductTemplateId,ShowOnHomePage,MetaKeywords,MetaDescription,MetaTitle,IsRental,RentalPriceLength,RentalPricePeriodId,IsTaxExempt,TaxCategoryId,StockQuantity,DisplayStockAvailability,DisplayStockQuantity,MinStockQuantity,OrderMinimumQuantity,OrderMaximumQuantity,DisableBuyButton,DisableWishlistButton,Price,OldPrice,SpecialPrice,SpecialPriceStartDateTimeUtc,SpecialPriceEndDateTimeUtc,Weight,Length,Width,Height,AvailableStartDateTimeUtc,AvailableEndDateTimeUtc,DisplayOrder,Published,Deleted,CreatedOnUtc,UpdatedOnUtc")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductTypeId,ParentGroupedProductId,VisibleIndividually,Name,ShortDescription,FullDescription,AdminComment,ProductTemplateId,ShowOnHomePage,MetaKeywords,MetaDescription,MetaTitle,IsRental,RentalPriceLength,RentalPricePeriodId,IsTaxExempt,TaxCategoryId,StockQuantity,DisplayStockAvailability,DisplayStockQuantity,MinStockQuantity,OrderMinimumQuantity,OrderMaximumQuantity,DisableBuyButton,DisableWishlistButton,Price,OldPrice,SpecialPrice,SpecialPriceStartDateTimeUtc,SpecialPriceEndDateTimeUtc,Weight,Length,Width,Height,AvailableStartDateTimeUtc,AvailableEndDateTimeUtc,DisplayOrder,Published,Deleted,CreatedOnUtc,UpdatedOnUtc")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
