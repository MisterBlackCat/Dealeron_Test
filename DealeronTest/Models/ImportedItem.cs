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
            this.itemName = itemName;
            this.itemPrice = (itemPrice * 1.05f);
            this.itemID = itemID;
        }
        public override float GetTax()
        {
            if (taxExcempt)
            {
                return 0;
            }
            else
            {
                return  (itemPrice * .1f);// + (.05f - (itemPrice % .05f)));
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
                ",\"Name\": \"Imported " + this.itemName + "\"" +
                ", \"FinalPrice\":" + this.GetFullPrice() + "" +
                ", \"ItemPrice\": " + itemPrice + " }";
        }
    }
}
