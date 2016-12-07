using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SLCore.Services;
using SLCore.ViewModels;

namespace SoftLabs.Controllers
{
   
    public class HomeController : Controller
    {
        LabService service = new LabService();
        public IActionResult Index()
        {
            return View();
        }

   
        
        [HttpGet]
        public async Task<JsonResult> GetMessages()
        {

            var orders = await service.GetMessages();

            return Json(orders);
        }


       
        [HttpPost]
        public async Task<JsonResult> AddMessage([FromBody]MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.AddMessage(model);

                return Json("Success");
            }
            return Json("NoSuccess");
        }

        [HttpDelete]
        public async Task DeleteMessage(string id)
        {
            await service.DeleteMessage(id);
        }
    }
}
