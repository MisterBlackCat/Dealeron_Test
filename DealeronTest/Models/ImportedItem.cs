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
                return itemPrice * .05f;
            }
            else
            {
                return  (itemPrice * .15f);// + (.05f - (itemPrice % .05f)));
            }
        }
        public override float GetFullPrice()
        {
            if (!taxExcempt)
            {
                float finalPrice = itemPrice + (itemPrice * .15f);
                return finalPrice;// + (.05f - (finalPrice % .05f));
            }
            else
            {
                return itemPrice + (itemPrice * .05f);
            }
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
