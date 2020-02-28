using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAPIRepository _iaprepository;
        public ProductsController(IAPIRepository iaprepository, ILogger<ProductsController> logger)
        {
            _iaprepository=iaprepository;
        }
        
        // GET api/product
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var product= await _iaprepository.GetAllProducts();
            return Ok(product);
        }

        // GET api/product/<cat?> i.e. Poster
        [HttpGet("{category}")]
        public async Task<ActionResult> Get(string category)
        {
            var product= await _iaprepository.GetProductsByCategory(category);
            return Ok(product);
        }

    }
}