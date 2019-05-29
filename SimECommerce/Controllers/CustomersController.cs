using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimECommerce.Models;

namespace SimECommerce.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ECommerceSimplifieContext _context;

        public CustomersController(ECommerceSimplifieContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var eCommerceSimplifieContext = _context.Customer.Include(c => c.BillingAddress).Include(c => c.ShippingAddress);
            return View(await eCommerceSimplifieContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.BillingAddress)
                .Include(c => c.ShippingAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["BillingAddressId"] = new SelectList(_context.Address, "Id", "Id");
            ViewData["ShippingAddressId"] = new SelectList(_context.Address, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerGuid,Username,Email,Password,PasswordFormatId,PasswordSalt,AdminComment,IsTaxExempt,AffiliateId,VendorId,HasShoppingCartItems,Active,Deleted,IsSystemAccount,SystemName,LastIpAddress,CreatedOnUtc,LastLoginDateUtc,LastActivityDateUtc,BillingAddressId,ShippingAddressId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.BillingAddressId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.ShippingAddressId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["BillingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.BillingAddressId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.ShippingAddressId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerGuid,Username,Email,Password,PasswordFormatId,PasswordSalt,AdminComment,IsTaxExempt,AffiliateId,VendorId,HasShoppingCartItems,Active,Deleted,IsSystemAccount,SystemName,LastIpAddress,CreatedOnUtc,LastLoginDateUtc,LastActivityDateUtc,BillingAddressId,ShippingAddressId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["BillingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.BillingAddressId);
            ViewData["ShippingAddressId"] = new SelectList(_context.Address, "Id", "Id", customer.ShippingAddressId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.BillingAddress)
                .Include(c => c.ShippingAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
