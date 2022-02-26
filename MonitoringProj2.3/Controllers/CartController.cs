using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            string apiUrl = "https://monitoringproj20220224133719.azurewebsites.net/api/cart";
            IEnumerable<Cart> model = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Cart>>(data);
                    model = obj.Select(i => new Cart
                    {
                        Id = i.Id, 
                        Items = i.Items,    
                        PunchTimestamp = i.Timestamp,
                        Purchased = i.Purchased,
                        Timestamp = i.Timestamp,
                        Visit = i.Visit,
                        VisitId = i.VisitId,
                    });
                }
            }
            return View(model);
        }
    }
}
