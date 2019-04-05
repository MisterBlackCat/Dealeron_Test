using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Utils
{
    public class JSONPair
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public JSONPair(string key, object value)
        {
            this.Key = key;
            this.Value = value; 
        }
    }
}
