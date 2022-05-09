using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Portal.Services;
using Portal.ViewModels;
using System;
using System.Threading.Tasks;


namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        public IEmailService emailService;

        public readonly IConfiguration Config;
        public FormDataController(IConfiguration configuration, IEmailService _emailservice)
        {
            emailService = _emailservice;
            Config = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]EmailFormViewModel data)
        {
            try
            {
                await emailService.SendEmailAsync(data);
                return Ok();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}