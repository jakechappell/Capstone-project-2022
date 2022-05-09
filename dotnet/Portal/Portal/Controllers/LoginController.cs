using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using Portal.ViewModels;
using System;
using System.Threading.Tasks;
using Org.BouncyCastle.Math.EC;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService service;
        public LoginController(ILoginService _service)
        {
            service = _service;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<string> Post([FromBody] LoginViewModel model)
        {
            return await service.LoginUser(model);
        }
    }
}
