using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MonitoringProj2._3.Models.ViewModels;

namespace MonitoringProj2._3.Controllers
{
    public class CartItemController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://monitoringproj20220224133719.azurewebsites.net/api/cartitem";
            IEnumerable<CartItem> model = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<CartItem>>(data);
                    model = obj.Select(i => new CartItem
                    {
                        Id = i.Id,
                        Item = i.Item,
                        Timestamp = i.Timestamp,
                        CartId = i.CartId,
                        Cart = i.Cart,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                        Removed = i.Removed

                    });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ItemChart()
        {
            string apiUrl = "https://monitoringproj20220224133719.azurewebsites.net/api/cartitem";
            IEnumerable<ItemQuantityVM> model = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<CartItem>>(data);
                    model = obj.Select(i => new ItemQuantityVM
                    {
                        Item = i.Item,
                        Quantity = i.Quantity,
                    });

                    List<ItemQuantityVM> cartItems = new List<ItemQuantityVM>();

                    foreach (var i in model)
                    {
                        cartItems.Add(i);
                    }

                    ViewBag.ItemQuantityVM = JsonConvert.SerializeObject(cartItems);
                }
            }

            return View();
        }
    }
}
