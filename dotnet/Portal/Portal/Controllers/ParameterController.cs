using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private IParameterService service; 
        public ParameterController(IParameterService serve)
        {
            service = serve;
        }


        // PUT api/<ParameterController>/5
        [HttpPut]
        public IActionResult Put(EditParameterDescriptionViewModel model)
        {
            try
            {
                // List<IActionResult> p = null;
                model.FillParamDictionary();
                foreach (var key in model.ParameterEditsDictionary.Keys)
                {
                    var parameter = service.EditParameterDescription(model, key);
                }
                return Ok();
            }
            catch(Exception ex)
            {
                if(ex.Message == "Not Found")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
