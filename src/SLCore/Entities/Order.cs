
using SLCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.Entities
{
    public class Order : BaseEntitiy
    {
        public Order()
        {

        }
        public Order(OrderViewModel model)
        {
            Id = Guid.NewGuid().ToString();
            FullName = model.FullName;
            Email = model.Email;
            Phone = model.Phone;
            Description = model.Description;
            SiteType = model.SiteType;
            PrimaryPrice = model.PrimaryPrice;
            Color1 = model.Color1;
            Color2 = model.Color2;
            Color3 = model.Color3;
            IsChat = model.IsChat;
            IsAuth = model.IsAuth;
            IsForum = model.IsForum;
            FuncDescription = model.FuncDescription;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string  Description{ get; set; }
        public string SiteType { get; set; }
        public decimal PrimaryPrice { get; set; }
        public string Color1  { get; set; }
        public string Color2 { get; set; }

        public string Color3 { get; set; }
        public bool IsChat { get; set; }
        public bool IsForum { get; set; }
        public bool IsAuth { get; set; }
        public string FuncDescription { get; set; }
    }
}
