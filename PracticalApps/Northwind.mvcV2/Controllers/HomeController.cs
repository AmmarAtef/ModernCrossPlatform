using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Common.Models;
using Northwind.Mvc.Models;
using Northwind.mvcV2.Models;
using System.Diagnostics;

namespace Northwind.mvcV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            _logger.LogError("This is a serious error (not really!)");
            _logger.LogWarning("This is your first warning!");
            _logger.LogWarning("Second warning1!");
            _logger.LogInformation("I am in the Index method of the HomeController.");

            HomeIndexViewModel model = new HomeIndexViewModel((new Random()).Next(1, 1001),
               await db.Categories.ToListAsync(),
               await db.Products.ToListAsync());

            return View(model); // pass model to view 
        }


        [Route("private")]
        [Authorize(Roles = "Administrators")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("you must pass product id in the route, for example, /Home/ProductSetails/21");

            }

            Product? model = await db.Products.SingleOrDefaultAsync(c => c.ProductId == id);

            if (model == null)
            {
                return NotFound($"ProductId {id} not found.");
            }

            return View(model);
        }


        public IActionResult ModelBinding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new HomeModelBindingViewModel(
                thing,
                !ModelState.IsValid,
                ModelState.Values
                .SelectMany(c => c.Errors)
                .Select(e => e.ErrorMessage)
                );
            return View(model);
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return BadRequest("you must pass a product price in the query string ," +
                    "for example, /Home/ProductsThatCostMoreThan?price=50");
            }

            IEnumerable<Product> model = db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(c => c.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No products cost more than {price:C}.");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");

            return View(model);
        }

    }
}