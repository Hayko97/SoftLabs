
using SLCore.Entities;
using SLCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.DbHelpers
{
    public class MessageHelper : HelperBase, IHelper<Message>
    {
        public async Task AddItem(Message model)
        {
            await Connection.OpenAsync();

            SqlCommand comand = Connection.CreateCommand();

            string query = StringBuilder
               .Append("INSERT INTO Messages (Name, Email,Message)")
               .Append("VALUES('")
               .Append(model.Name)
               .Append("','").Append(model.Email)
               .Append("','").Append(model.Description).Append("');").ToString();

            comand.CommandText = query;

            await comand.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task DeleteItem(string id)
        {
            await Connection.OpenAsync();
            SqlCommand comand = Connection.CreateCommand();
            comand.CommandText = "DELETE FROM Messages WHERE Id = '" + id + "'";
            await comand.ExecuteNonQueryAsync();
            Connection.Close();
        }

        public async Task<List<Message>> GetAllItems()
        {
            await Connection.OpenAsync();

            SqlCommand comand = Connection.CreateCommand();
            comand.CommandText = "SELECT Name, Email,Message  FROM Messages";
            SqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Message> orderList = new List<Message>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    var order = new Message
                    {
                        Name = reader.GetString(0),
                        Email = reader.GetString(1),
                        Description = reader.GetString(2)
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
