using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Models
{
    public abstract class Item
    {

        public string itemName { get; set; }
        public int itemID { get; set; }
        public float itemPrice { get; set; }
        public bool taxExcempt { get; set; }
        public Item(int itemID, float itemPrice, string itemName)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemID = itemID;
            this.taxExcempt = false;
        }
        protected Item() { }
        public abstract float GetTax();
        public abstract float GetFullPrice();
        public abstract string GetJSONObject();
    }
}
