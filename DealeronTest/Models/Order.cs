using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Models
{
    public class Order
    {

        public int ID { get; set; }
        public float tax { get; set; }
        public float total { get; set; }
        public List<Item> items { get; set; }



    }
}
