using MonitoringProj2._3.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    /// <summary>
    /// Helper Class, that keeps controller class clean of Http Client Code
    /// </summary>
    public class APIVisitRepository
    {
        public APIVisitRepository()
        {

        }

        /// <summary>
        /// Used for returning all visits in database
        /// Creates visit objects based on the JSON that is returned from API
        /// Uses HttpClient to send a GET request to API
        /// The GET request is for the visit items in the visit table of the database
        /// </summary>
        /// <returns> A list of all Visits</returns>
        public async Task<IEnumerable<Visit>> ReadAllAsync()
        {
            string apiUrl = "https://monitoringprojfix1.azurewebsites.net/api/visits";
            IEnumerable<Visit> model = null;

            //Creating a new HttpClient Obj to create GET Request
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                //Creation of GET Request
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode) // If connection is sucessful
                {
                    var data = await response.Content.ReadAsStringAsync();
                    
                    //Converts the JSON into an object (Desearlizes) 
                    var obj = JsonConvert.DeserializeObject<ICollection<Visit>>(data);
                    model = obj.Select(i => new Visit
                    {
                        Id = i.Id,
                        Ip = i.Ip,
                        Timestamp = i.Timestamp,
                        DeviceSource = i.DeviceSource
                    });
                }
            }

            return model;
        }
    }
}
