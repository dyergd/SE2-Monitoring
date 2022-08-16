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

        public async Task<IActionResult> MarketBasket()
        {
            var model = await cartItemRepository.ReadAllAsync();
            string json = JsonConvert.SerializeObject(model);
            ViewBag.model = json;
            return View(model);
        }

        public async Task<IActionResult> ItemStats([FromForm]string SearchString) 
        {
            var model = await cartItemRepository.ItemDetails(SearchString);
         
            List<ItemAverageVM> itemAverageVMs = new List<ItemAverageVM>();
            IEnumerable<ItemAverageVM> model2 = null;
            ItemAverageVM ItemAverageobj = new ItemAverageVM();

            foreach (var j in model)
            {
                ItemAverageobj.Item = j.Item;
                ItemAverageobj.CostList.Add(j.Cost);
                ItemAverageobj.DateTimeList.Add(j.Timestamp);
                ItemAverageobj.TotalSoldList.Add(j.Quantity);

                ItemAverageobj.LowPrice = ItemAverageobj.CostList.Min();
                ItemAverageobj.HighPrice = ItemAverageobj.CostList.Max();
                ItemAverageobj.Average = ItemAverageobj.CostList.Average();
                ItemAverageobj.Month = j.Timestamp.Month; //does not provide actual data needs more work
                ItemAverageobj.TotalSold = ItemAverageobj.TotalSoldList.Sum();
                if(j.Removed == true)
                {
                    ItemAverageobj.Removed++;
                }
            }

            itemAverageVMs.Add(ItemAverageobj);

            model2 = itemAverageVMs;

            return View(model2);
        }

        public async Task<IActionResult> TestMarketBasket()
        {
            return View();
        }

    }
}
