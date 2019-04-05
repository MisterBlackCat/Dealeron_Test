using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Utils
{
    public class JSONObject
    {

        public List<string> keys { get; set; }
        public List<JSONPair> pairs { get; set; }

        public JSONObject(string json)
        {
            this.keys = new List<string>();
            this.pairs = new List<JSONPair>();

            string[] raw = json.Split(","); 
            foreach(string kv in raw)
            {
                keys.Add(kv.Replace("\"", "").Split(':')[0]);
                JSONPair pair = new JSONPair(kv.Replace("\"", "").Split(':')[0],
                    kv.Replace("\"", "").Split(':')[1]);
                pairs.Add(pair); 
            }
        }

        public object GetValue(string key)
        {
            foreach(JSONPair pair in pairs)
            {
                if(pair.Key == key)
                {
                    return pair.Value; 
                }
            }
            return null; 
        }
        public bool CheckForKey(string key)
        {
            foreach (JSONPair pair in pairs)
            {
                if (pair.Key == key)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
