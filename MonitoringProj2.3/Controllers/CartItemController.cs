using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MonitoringProj2._3.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MonitoringProj2._3.Services;

namespace MonitoringProj2._3.Controllers
{
    public class CartItemController : Controller
    {
        APICartItemRepository cartItemRepository = new APICartItemRepository();

        public async Task<IActionResult> Index()
        {
            var model = await cartItemRepository.ReadAllAsync();
            return View(model);
        }

        public async Task<IActionResult> ItemChart()
        {
            string apiUrl = "https://monitoringproj20220224133719.azurewebsites.net/api/cartitem";
            IEnumerable<InventoryVM> model = null;

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
                    model = obj.Select(i => new InventoryVM
                    {
                        Item = i.Item,
                        Quantity = i.Quantity,
                    });

                    List<string> cartItems = new List<string>();
                    List<int> itemQuantity = new List<int>();


                    foreach (var i in model)
                    {
                        cartItems.Add(i.Item);
                        itemQuantity.Add(i.Quantity);
                    }

                    ViewBag.ItemQuantity = itemQuantity;
                    ViewBag.CartItems = cartItems;
                }
            }

            return View();
        }

        public async Task<IActionResult> ItemFrequency()
        {
            string apiUrl = "https://monitoringproj20220224133719.azurewebsites.net/api/cartitem";
            IEnumerable<InventoryVM> model = null;

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
                    model = obj.Select(i => new InventoryVM
                    {
                        Item = i.Item,
                        Timestamp = i.Timestamp,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                        TotalCost = i.Cost * i.Quantity
                    });

                }
            }
            return View(model);
        }

    }
}
