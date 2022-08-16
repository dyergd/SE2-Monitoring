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
            string apiUrl = "https://monitoringprojfix1.azurewebsites.net/api/cartitem";
            IEnumerable<InventoryVM> model = null; //creates a IEnumerable of InventoryVM to populate later

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl); //grabs the response message of the api call
                if (response.IsSuccessStatusCode) // if the request was a success run code
                {
                    var data = await response.Content.ReadAsStringAsync(); //converts the response into a string
                    var obj = JsonConvert.DeserializeObject<ICollection<CartItem>>(data); //deserializes the json into a ICollection of cart items
                    model = obj.Select(i => new InventoryVM //populates the IEnumberable of InventoryVM with the data returned from the API
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

        public async Task<IEnumerable<InventoryVM>> ItemDetails(string item) //used to read a specific item from the API
        {
            var model = await ReadAllAsync(); //grabs all the cart item data from the API
            model = model.Where(p => p.Item == item); //filters the data based on the searched item
            return model;
        }





    }
}
