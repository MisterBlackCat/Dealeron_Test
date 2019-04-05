using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Utils
{
    public class JSONArray
    {
        public List<JSONObject> jsonObjects { get; set; }
        public JSONArray()
        {
            this.jsonObjects = new List<JSONObject>(); 
        }
    }
}
