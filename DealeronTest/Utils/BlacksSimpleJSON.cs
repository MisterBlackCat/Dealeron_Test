using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Utils
{
    public class BlacksSimpleJSON
    {
        public static JSONArray ParseArray(string json)
        {
            JSONArray ar = new JSONArray(); 
            json = json.Replace("[", "");
            json = json.Replace("]", "");
            string[] objs = json.Split("},{");
            for(int x = 0; x < objs.Length; x++)
            {
                objs[x] = objs[x].Replace("{", "");
                objs[x] = objs[x].Replace("}", "");
            }
            foreach(string obj in objs)
            {
                JSONObject j = new JSONObject(obj);
                ar.jsonObjects.Add(j); 
            }
            return ar; 
        }
    }
}
