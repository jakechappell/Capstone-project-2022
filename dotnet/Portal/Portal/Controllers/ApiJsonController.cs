using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiJsonController : ControllerBase
    {
        public IApiJsonService service;
        public ApiJsonController(IApiJsonService _service)
        {
            service = _service;
        }
        
        [HttpGet]
        public void Get()
        {
            var data = service.GetApiJson();
            try
            {
                service.SaveData(data);
                Console.WriteLine("Done with loading");
            }
            catch (Exception ex)
            {
                Console.WriteLine("THERE WAS AN ERROR WITH LOADING THE DATA: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
