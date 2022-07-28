using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlace.Models;
using MarketPlace.Services;

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
        public IActionResult GetProducts()
        {
            IEnumerable<Product> list = _service.GetProducts();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();


        }

        [HttpGet("{name}", Name = "GetProduct")]
        public IActionResult GetProductByName(string name)
        {
            Product obj = _service.GetProductByName(name);
            if (obj != null)
                return Ok(obj);

            return BadRequest();

        }

        [HttpGet("{ItemID}/ItemID")]// for queries curly braces mean variable 

        public IActionResult GetProductByItemID(string ItemID)
        {


            Product obj = _service.GetProductByItemID(ItemID);
            if (obj != null)

                return Ok(obj);

            return BadRequest();

        }

        [HttpPost]
        public IActionResult CreateProduct(Product m)
        {

            _service.CreateProduct(m);
            // might need to add code to return if successful
            return CreatedAtRoute("GetProduct", new { name = m.Name }, m);

        }



        [HttpPut("{name}")]
        public IActionResult UpdateProduct(string name, Product productIn)
        {

            _service.UpdateProduct(name, productIn);
            return NoContent();


        }


        [HttpDelete("{name}")]
        public IActionResult DeleteProduct(string name)
        {

            _service.DeleteProduct(name);
            return NoContent();

        }




    }
}

