using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Models
{
    public class ImportedItem : Item
    {
        public ImportedItem(int itemID, float itemPrice, string itemName)
        {
            this.itemName = "Imported " + itemName;
            this.itemPrice = (itemPrice);// * 1.05f);
            this.itemID = itemID;
        }
        public override float GetTax()
        {
            if (taxExcempt)
            {
                float withTax = (itemPrice * .05f); 
                float n = (withTax) + (.05f - (withTax % .05f));
                return n;
            }
            else
            {
                float withTax = (itemPrice * .15f);
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
                ", \"ItemPrice\": " + (itemPrice) + " }";
        }
    }
}
