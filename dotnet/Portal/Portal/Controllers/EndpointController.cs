using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using Portal.ViewModels;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private IEndpointService service;
        public EndpointController(IEndpointService serv)
        {
            service = serv;
        }

        // PUT api/<EndpointController>/
        [HttpPut]
        public IActionResult Put(EditEndpointDescriptionViewModel model)
        {
            try
            {
                var endpoint = service.EditEndpointDescription(model);
                return Ok(endpoint);
            }
            catch (Exception ex)
            {
                if (ex.Message == "NotFound")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("{id}")]
        public EndpointViewModel Get(int id)
        {
            return service.GetEndpointById(id);
        }
    }
}
