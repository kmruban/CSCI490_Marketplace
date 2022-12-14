using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlace.Models;
using MarketPlace.Services;
using System.Threading.Tasks;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductServices _service;
        public ProductController(ILogger<ProductController> logger, IProductServices services)
        {
            _logger = logger;
            _service = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            IList<Product> list = await _service.GetProducts();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{Name}/name")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            IList<Product> list = await _service.GetProductByName(name);
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{ItemID}/itemid")] 
        public async Task<IActionResult> GetProductByItemID(int ItemID)
        {
            Product obj = await _service.GetProductByItemID(ItemID);
            if (obj != null)
                return Ok(obj);

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product m)
        {
            _service.CreateProduct(m);
            return Ok(m);

        }

        [HttpPut("{ItemID}/update")]
        public IActionResult UpdateProduct(int ItemID, Product productIn)
        {
            _service.UpdateProduct(ItemID, productIn);
            return NoContent();
        }


        [HttpDelete("{ItemID}")]
        public IActionResult DeleteProduct(int ItemID)
        {
            _service.DeleteProduct(ItemID);
            return NoContent();
        }

    }
}

