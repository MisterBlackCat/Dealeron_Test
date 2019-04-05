using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DealeronTest.Models
{
    public static class DBAccess
    {
        public static string GetConnString()
        {
            return DBAccess.Configuration.GetSection("ConnectionStrings")
                .GetSection("DearlonDB").Value;
        }
        public static IConfiguration Configuration; 
        public static void CreateOrder()
        {

        } 

        public static List<ItemForSale> GetOrder()
        {
            List<ItemForSale> order = new List<ItemForSale>();
            return order; 
        }

        public static Item GetItem(int ID)
        {
            ItemForSale item = null;
            SqlConnection conn = new SqlConnection(GetConnString());
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Items WHERE ID = " +
                "'" + ID + "';");
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            conn.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string test = reader.GetString(0);
                    Item i = null;
                    double testTwo = reader.GetDouble(1);
                    if (reader.GetBoolean(2))
                    {
                        i = new ImportedItem(reader.GetInt32(3), (float)reader.GetDouble(1),
                            reader.GetString(0));
                    }
                    else
                    {
                        i = new ItemForSale(reader.GetInt32(3), (float)reader.GetDouble(1),
                            reader.GetString(0));
                    }
                    if (reader.GetBoolean(4))
                    {
                        i.taxExcempt = true; 
                    }
                    return i; 
                }
            }
            conn.Close();
            return item; 
        }

        public static List<Item> GetItemsForSale()
        {
            List<Item> items = new List<Item>();
            SqlConnection conn = new SqlConnection(GetConnString());
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Items;");
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;
            conn.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string test = reader.GetString(0);
                    Item i = null;
                    double testTwo = reader.GetDouble(1);
                    if (reader.GetBoolean(2))
                    {
                        i = new ImportedItem(reader.GetInt32(3), (float)reader.GetDouble(1),
                            reader.GetString(0));
                    }
                    else
                    {
                        i = new ItemForSale(reader.GetInt32(3), (float)reader.GetDouble(1),
                            reader.GetString(0));
                    }
                    if (reader.GetBoolean(4))
                    {
                        i.taxExcempt = true;
                    }
                    items.Add(i); 
                }
            }
            conn.Close(); 
            return items; 
        }
    }
}
