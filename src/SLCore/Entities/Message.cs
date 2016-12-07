
using SLCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.Entities
{
    public class Message 
    {
        public Message(){ }

        public Message(MessageViewModel model)
        {
            Name = model.Name;
            Email = model.Email;
            Description = model.Message;
        } 
        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}
