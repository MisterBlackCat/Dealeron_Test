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
                float withTax = (itemPrice * .1f);
                float n = (withTax) + (.05f - (withTax % .05f));
                return n;
            }
        }

        public override float GetFullPrice()
        {
            return itemPrice + GetTax();
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
