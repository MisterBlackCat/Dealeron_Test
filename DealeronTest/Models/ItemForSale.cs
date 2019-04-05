using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Models
{
    public class ItemForSale : Item
    {
        public ItemForSale(int itemID, float itemPrice, string itemName)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemID = itemID;
            this.taxExcempt = false; 
        }
        protected ItemForSale() { }

        public override float GetTax()
        {
            if (taxExcempt)
            {
                return 0;
            }
            else
            {
                return (itemPrice * .1f);
            }
        }
        public override float GetFullPrice()
        {
            if (!taxExcempt)
            {
                float finalPrice = itemPrice + (itemPrice * .1f);
                return finalPrice + (.05f - (finalPrice % .05f));
            }
            else
            {
                return itemPrice;
            }
        }
        public override string GetJSONObject()
        {
            return "{ \"ID\": " + this.itemID + 
                ",\"Name\": \"" + this.itemName + "\"" +
                ", \"FinalPrice\":" + this.GetFullPrice() + "" +
                ", \"ItemPrice\": " + itemPrice + " }"; 
        }
    }
}
