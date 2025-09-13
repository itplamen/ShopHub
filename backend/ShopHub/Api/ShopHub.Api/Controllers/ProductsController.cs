namespace ShopHub.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ShopHub.Services.Data.Contracts;
    using ShopHub.Services.Models.Product;

    //[Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;   
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductRequest request) 
        {
            IEnumerable<ProductResponse> products = await productsService.GetAll(request);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            ProductResponse product = await productsService.GetById(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

    }
}
