using AlphaSoftAPI.Models;
using AlphaSoftAPI.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlphaSoftAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductsContext productsContext)
        {
            _productsContext = productsContext;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "OAuth oauth_token=AQAAAAA_TV-pAAdmu8A4dGtMIENpsYyy4eDcTu0, oauth_client_id=43e9dd3fa24846dbb166752bceb1a8e6");
        }
        private readonly HttpClient _httpClient;
        private readonly ProductsContext _productsContext;

        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            _productsContext.Products.Add(product);

            await _productsContext.SaveChangesAsync();

            return Ok(_productsContext.Products);
        }

        [HttpPost("send")] 
        public async Task<IActionResult> Send(Root root)
        {
            var messages = await TelegramModule.SendMessageAsync(root.Order);

            Console.WriteLine("Началась отправка ключа");

            var yandexItems = new List<YandexItem>();

            TelegramModule.EditMessageAsync(messages, root.Order, $"Поиск ключа", "Не найден");

            foreach (var item in root.Order.Items)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));

                Console.WriteLine($"Поиск ключа по OfferId: {item.OfferId}");

                for (int i = 0; i < item.Count; i += 1)
                {
                    var product = _productsContext.GetProductAsync(item.OfferId);

                    yandexItems.Add(new YandexItem()
                    {
                        Id = item.Id,
                        activate_till = product.ActivateTill,
                        Code = product.Code,
                        Slip = product.Slip
                    });

                    await Task.Delay(1000);

                    try
                    {
                        _productsContext.SaveChanges();
                    }
                    catch
                    { }
                    
                    Console.WriteLine($"Отправляю код: ID: {item.Id} - Code: {product.Code} - Slip: {product.Slip}");
                }


            }

            //TelegramModule.EditMessageAsync(messages, root.Order, $"Отправляю ключ на почту", $"{yandexItems.First().Code}");

            Console.WriteLine(JsonConvert.SerializeObject(yandexItems));

            var response = await _httpClient.PostAsJsonAsync($"https://api.partner.market.yandex.ru/v2/campaigns/22013904/orders/{root.Order.Id}/deliverDigitalGoods.json", new
            {
                items = yandexItems
            });

            //TelegramModule.EditMessageAsync(messages, root.Order, $"Ключ успешно отправлен", $"{yandexItems.First().Code}");

            Console.WriteLine(response);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            root.Order.Status = "COMPLETED";

            TelegramModule.EditMessageAsync(messages, root.Order, $"Отправлено. Тело ответа от сервера: {await response.Content.ReadAsStringAsync()}\n\nКод ответа: {response.IsSuccessStatusCode}", $"{yandexItems.First().Code}");

            return Ok();
        }
    }
}
