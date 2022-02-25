using MonitoringProj2._3.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    public class APICartItemRepository
    {
        public APICartItemRepository()
        {

        }

        public async Task<IEnumerable<InventoryVM>> ReadAllAsync()
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
                    var obj = JsonConvert.DeserializeObject<ICollection<CartItem>>(data);
                    model = obj.Select(i => new InventoryVM
                    {
                        Id = i.Id,
                        Item = i.Item,
                        Timestamp = i.Timestamp,
                        CartId = i.CartId,
                        Cart = i.Cart,
                        Quantity = i.Quantity,
                        Cost = i.Cost,
                        Removed = i.Removed,
                        TotalCost = i.Cost * i.Quantity

                    });
                }
            }

            return model;
        }





    }
}
