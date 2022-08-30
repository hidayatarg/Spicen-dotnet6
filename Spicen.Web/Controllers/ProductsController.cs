using Microsoft.AspNetCore.Mvc;
using Spicen.Core;
using Spicen.Core.Services;

namespace Spicen.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        // DI
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetProductsWithCategory();

            return View(response.Data);
        }
    }
}
