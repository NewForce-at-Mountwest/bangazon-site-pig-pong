using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonSite.Data;
using BangazonSite.Models;
using BangazonSite.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace BangazonSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;
        }
        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Products
        public async Task<IActionResult> Index(string searchQuery)
        {

            var products = await _context.Products.Include(p => p.ProductType).Include(p => p.User).ToListAsync();
            // typing into the search field to match a product title
            if (searchQuery != null)
            {
                products = products.Where(product => product.Title.ToLower().Contains(searchQuery)).ToList();
            }
            return View(products);

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.User)
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
            SellAProductViewModel sellAProductViewModel = new SellAProductViewModel();
            sellAProductViewModel.ListOfProductTypes = _context.ProductTypes.Select(pt => new SelectListItem
            {
                Value = pt.Id.ToString(),
                Text = pt.Name
            }).ToList();
            sellAProductViewModel.ListOfProductTypes.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a Product Type"
            });
            return View(sellAProductViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SellAProductViewModel sellAProductViewModel)
        {
            ModelState.Remove("product.UserId");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                if (sellAProductViewModel.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await sellAProductViewModel.ImageFile.CopyToAsync(memoryStream);
                        sellAProductViewModel.Product.ProductImage = memoryStream.ToArray();
                    }
                };

                sellAProductViewModel.Product.UserId = user.Id;
                _context.Add( sellAProductViewModel.Product);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = sellAProductViewModel.Product.Id.ToString() });
            }
            else
            {

            }
            return View(sellAProductViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Description,Title,Price,Quantity,UserId,City,ProductImage,LocalDelivery,ProductTypeId,Active")] Product product)
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.User)
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
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Types()
        {
            ProductTypesViewModel vm = new ProductTypesViewModel();
            //list of product types
            var productTypes = _context.ProductTypes
            //include the products
            .Include(p => p.Products).ToList();
            //I have alist of product types, need to convert to grouped list
            var groupedProducts = new List<GroupedProducts>();
            foreach (ProductType p in productTypes)
            {
                groupedProducts.Add(new GroupedProducts()
                {
                    TypeName = p.Name,
                    ProductCount = p.Products.Count(),
                    Products = p.Products.Take(3).ToList()
                });
            }

            vm.GroupedProducts = groupedProducts;
            return View(vm);
        }
        //method for adding product to cart. Check for open order, if they don't have a new order, "CREATE" new. If they do, use open order's Id
        public async Task<IActionResult> AddToCart(int id)
        {

             
             var user =  await _userManager.GetUserAsync(HttpContext.User);
            var addToCart =  await _context.Orders
                .Include(p => p.PaymentType)
                .Include(p => p.User)
               .FirstOrDefaultAsync(p => p.PaymentTypeId == null);
           

            if (addToCart == null)
            {
                addToCart = new Order
                {
                    UserId = user.Id,
                    PaymentTypeId = null
                };
                _context.Orders.Add(addToCart);
                
            }

            OrderProduct op = new OrderProduct
            {
                OrderId = addToCart.Id,
                ProductId = id
            };
            _context.OrderProducts.Add(op);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders");
        }
    }
}
