
using SLCore.Entities;
using SLCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.DbHelpers
{
    public class OrderHelper : HelperBase,IHelper<Order>
    {
        public async Task AddItem(Order model)
        {
           await Connection.OpenAsync();

            SqlCommand comand = Connection.CreateCommand();

            string query = StringBuilder
                .Append("INSERT INTO Orders (Id,FullName, Email,  Phone, Description,SiteType,PrimaryPrice,Color1,Color2,Color3,IsChat,IsForum,IsAuth,FuncDescription)")
                .Append("VALUES('")
                .Append(model.Id)
                .Append("','").Append(model.FullName)
                .Append("','").Append(model.Email)
                .Append("','").Append(model.Phone)
                .Append("','").Append(model.Description)
                .Append("','").Append(model.SiteType)
                .Append("','").Append(model.PrimaryPrice)
                .Append("','").Append(model.Color1)
                .Append("','").Append(model.Color2)
                .Append("','").Append(model.Color3)
                .Append("','").Append(model.IsChat)
                .Append("','").Append(model.IsForum)
                .Append("','").Append(model.IsAuth)
                .Append("','").Append(model.FuncDescription).Append("');").ToString();

            

            comand.CommandText = query;

            await comand.ExecuteNonQueryAsync();

            Connection.Close();
             
        }

        public async Task DeleteItem(string id)
        {
            await Connection.OpenAsync();
            SqlCommand comand = Connection.CreateCommand();
            comand.CommandText = "DELETE FROM Orders WHERE Id = '"+id+"'";
            await comand.ExecuteNonQueryAsync();
            Connection.Close();
        }

        public async Task<List<Order>> GetAllItems()
        {
            await Connection.OpenAsync();

            SqlCommand comand = Connection.CreateCommand();
            comand.CommandText = "SELECT Id,FullName, Email,  Phone, Description,SiteType,PrimaryPrice,Color1,Color2,Color3,IsChat,IsForum,IsAuth,FuncDescription  FROM Orders";
            SqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Order>  orderList = new List<Order>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   
                    var order = new Order {
                        Id = reader.GetString(0),
                        FullName = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Description = reader.GetString(4),
                        SiteType = reader.GetString(5),
                        PrimaryPrice = reader.GetDecimal(6),
                        Color1 = reader.GetString(7),
                        Color2 = reader.GetString(8),
                        Color3 = reader.GetString(9),
                        IsChat = reader.GetBoolean(10),
                        IsForum = reader.GetBoolean(11),
                        IsAuth = reader.GetBoolean(12),
                        FuncDescription = reader.GetString(13)

                    };

                    orderList.Add(order);

                }
                reader.Dispose();
                Connection.Close();
                return orderList;
            }
            else
            {
                reader.Dispose();
                Connection.Close();
                return null;
            }
            
           
            

            
        }

       
    }
}
