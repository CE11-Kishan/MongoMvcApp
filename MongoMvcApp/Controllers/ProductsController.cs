using Microsoft.AspNetCore.Mvc;
using MongoMvcApp.Models;

namespace MongoMvcApp.Controllers
{
      public class ProductsController : Controller
      {
            private readonly ProductRepository _repository;

            public ProductsController(ProductRepository repository)
            {
                  _repository = repository;
            }

            // GET: Products
            [HttpGet]
            public async Task<IActionResult> Index()
            {
                  var products = await _repository.GetProductsAsync();
                  return View(products);
            }

            // GET: Products/Details/id
            [HttpGet]
            public async Task<IActionResult> Details(string id)
            {
                  if (id == null)
                  {
                        return NotFound();
                  }

                  var product = await _repository.GetProductAsync(id);
                  if (product == null)
                  {
                        return NotFound();
                  }

                  return View(product);
            }

            // GET: Products/Create
            [HttpGet]
            public IActionResult Create()
            {
                  return View();
            }

            // POST: Products/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Product product)
            {
                  await _repository.CreateProductAsync(product);
                  return RedirectToAction(nameof(Index));
            }

            // GET: Products/Edit/id
            [HttpGet]
            public async Task<IActionResult> Edit(string id)
            {
                  if (id == null)
                  {
                        return NotFound();
                  }

                  var product = await _repository.GetProductAsync(id);
                  if (product == null)
                  {
                        return NotFound();
                  }

                  return View(product);
            }

            // POST: Products/Edit/id
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(string id, Product product)
            {
                  if (id != product.Id)
                  {
                        return NotFound();
                  }

                  if (ModelState.IsValid)
                  {
                        try
                        {
                              await _repository.UpdateProductAsync(id, product);
                        }
                        catch (Exception)
                        {
                              return NotFound();
                        }
                        return RedirectToAction(nameof(Index));
                  }
                  return View(product);
            }

            // GET: Products/Delete/id
            [HttpGet]
            public async Task<IActionResult> Delete(string id)
            {
                  if (id == null)
                  {
                        return NotFound();
                  }

                  var product = await _repository.GetProductAsync(id);
                  if (product == null)
                  {
                        return NotFound();
                  }

                  return View(product);
            }

            // POST: Products/Delete/id
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(string id)
            {
                  var product = await _repository.GetProductAsync(id);
                  if (product != null)
                  {
                        await _repository.RemoveProductAsync(id);
                  }
                  return RedirectToAction(nameof(Index));
            }
      }
}
