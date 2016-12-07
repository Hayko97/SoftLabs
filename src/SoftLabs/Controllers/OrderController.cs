using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SLCore.Services;
using SLCore.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftLabs.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        LabService service = new LabService();
        // GET: api/values
        [HttpGet]    
        public async Task<JsonResult> Get()
        {

            var orders = await service.GetOrders();

            return Json(orders);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]OrderViewModel model)
        { 
            if (ModelState.IsValid)
            {
                await service.AddOrder(model);

                return Json("Success");
            }
            return Json("NoSuccess");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await service.DeleteOrder(id);
        }
    }
}
