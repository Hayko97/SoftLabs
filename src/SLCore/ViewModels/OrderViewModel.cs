using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLCore.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Description { get; set; }
        public string SiteType { get; set; }
        public decimal PrimaryPrice { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }

        public string Color3 { get; set; }
        public bool IsChat { get; set; }
        public bool IsForum { get; set; }
        public bool IsAuth { get; set; }
        public string FuncDescription { get; set; }
    }
}
