using AlphaSoftAPI.Models.Stocks.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaSoftAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        public StocksController(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        private readonly ProductsContext _productsContext;

        [HttpPost]
        public IActionResult Stocks([FromBody] Root root)
        {
            Console.WriteLine("[*] Stocks");

            Console.WriteLine(JsonConvert.SerializeObject(root));

            var response = new Models.Stocks.Response.Root();

            response.Skus = new List<Models.Stocks.Response.Sku>();

            foreach (var skuItem in root.Skus)
            {
                response.Skus.Add(new Models.Stocks.Response.Sku()
                {
                    sku = skuItem,
                    WarehouseId = root.WarehouseId,
                    Items = new List<Models.Stocks.Response.Item>()
                    {
                        new Models.Stocks.Response.Item()
                        {
                            Count = _productsContext.Products.Where(p => p.OfferName == skuItem && !p.Activated).Count(),
                            Type = "FIT",
                            UpdatedAt = DateTime.Now
                        }
                    }
                });

               
                
            }



            Console.WriteLine("[*] Response");

            Console.WriteLine(JsonConvert.SerializeObject(response));

            return Ok(response);
        }
    }
}
