using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DealeronTest.Models;
using DealeronTest.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DealeronTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            string resp = "[ ";
            List<Item> items = DBAccess.GetItemsForSale();
            for (int x = 0; x < items.Count - 1; x++)
            {
                resp = resp + items[x].GetJSONObject() + ",";
            }
            resp = resp + items[items.Count - 1].GetJSONObject() + " ]";
            BlacksSimpleJSON.ParseArray(resp); 
            return resp;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string resp = "[ " + DBAccess.GetItem(id).GetJSONObject() + " ]";
            return resp; 
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            string x = "";
            using (var reader = new StreamReader(Request.Body))
            {
                x = reader.ReadToEnd();
            }
            JSONArray ar = BlacksSimpleJSON.ParseArray(x);
            List<ItemsPosted> items = new List<ItemsPosted>(); 
            foreach(JSONObject obj in ar.jsonObjects)
            {
                ItemsPosted p = new ItemsPosted();

                p.item = DBAccess.GetItem(int.Parse((string)obj.GetValue("ID")));
                p.count = int.Parse((string)obj.GetValue("count"));
                items.Add(p); 
            }
            DBAccess.CreateOrder(items, GetPrice(items) + GetSalesTax(items), GetSalesTax(items));
            string resp = "{ \"items\":[";
            for(int y = 0; y < items.Count - 1; y++)
            {
                resp = resp + "{\"Name\":\"" + items[y].item.itemName + "\"," +
                    "\"total\":\"" + items[y].item.GetFullPrice() * items[y].count + "\"," +
                    "\"count\":\"" + items[y].count + "\"," +
                    "\"price\":\"" + items[y].item.GetFullPrice() + "\"},";
            }
            resp = resp + "{\"Name\":\"" + items[items.Count - 1].item.itemName + "\"," +
                "\"total\":\"" + items[items.Count - 1].item.GetFullPrice() * items[items.Count - 1].count + "\"," +
                "\"count\":\"" + items[items.Count - 1].count + "\"," +
                "\"price\":\"" + items[items.Count - 1].item.GetFullPrice() + "\"}],";
            resp = resp + "\"tax\":\"" + GetSalesTax(items) + "\",";
            resp = resp + "\"total\":\"" + GetPrice(items) + "\"}";
            return resp; 
        }

        protected float GetPrice(List<ItemsPosted> items)
        {
            float total = 0; 
            foreach(ItemsPosted p in items)
            {
                total = total + p.item.itemPrice * p.count; 
            }
            total = total + GetSalesTax(items); 
            return total; 
        }

        protected float GetSalesTax(List<ItemsPosted> items)
        {
            float tax = 0; 
            foreach(ItemsPosted p in items)
            {

                tax = tax + p.item.GetTax() * p.count; 
            }
			if(tax == 0)
			{
				return tax;
			}
            return tax; 
        }
    }
}
