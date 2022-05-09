using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using Portal.ViewModels;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleController : ControllerBase
    {
        private IConsoleService service;
        public ConsoleController(IConsoleService serv)
        {
            service = serv;
        }
        [HttpPost]
        public async Task<IEnumerable<dynamic>> NormalUrl([FromBody] ConsoleViewModel model)
        {
            int timeout = 10000;
            var task = service.MakeConsoleCall(model);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return await task;
            }
            return new[] {"Response too large. Try adding a parameter."};
        }
        [HttpPost]
        [Route("dynamic")]
        public async Task<dynamic> DynamicUrl([FromBody] ConsoleViewModel model)
        {
            int timeout = 10000;
            var task = service.MakeConsoleCall_Dynamic(model);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return await task;
            }
            return "Response too large. Try adding a parameter.";
        }
    }
}
