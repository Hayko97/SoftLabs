

using SLCore.DbHelpers;
using SLCore.Entities;
using SLCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.Services
{
    public class LabService
    {
        OrderHelper oh = new OrderHelper();
        MessageHelper mh = new MessageHelper();

        public async Task AddOrder(OrderViewModel model)
        {
            var order = new Order(model);
            await oh.AddItem(order);
        }

        public async Task<IEnumerable<Order>> GetOrders() {
            var orderList = await oh.GetAllItems();

            return orderList;
        }

        public async Task AddMessage(MessageViewModel model)
        {
            var message = new Message(model);
            await mh.AddItem(message);
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            var messageList = await mh.GetAllItems();

            return messageList;

        }

        public async Task DeleteOrder(string id)
        {
            await oh.DeleteItem(id);
        }

        public async Task DeleteMessage(string id)
        {
            await oh.DeleteItem(id);
        }
    }
}
