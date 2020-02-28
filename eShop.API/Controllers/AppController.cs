using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAPIRepository _iaprepository;
        public AppController(IAPIRepository iaprepository )
        {
            _iaprepository=iaprepository;
        }
        // GET api/app
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var product= await _iaprepository.GetAllProducts();
            return Ok(product);
        }

        // GET api/app/<cat?> i.e. Poster
        [HttpGet("{category}")]
        public async Task<ActionResult> Get(string category)
        {
            var product= await _iaprepository.GetProductsByCategory(category);
            return Ok(product);
        }
        
    }
}