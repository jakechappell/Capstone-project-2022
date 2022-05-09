using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using Portal.ViewModels;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private ICollectionService service;
        public CollectionController(ICollectionService serv)
        {
            service = serv;
        }
        // GET: api/<CollectionController>
        [HttpGet]
        public List<CollectionViewModel> Get()
        {
            return service.GetAllCollections();
        }

        [HttpGet]
        [Route("sidebar")]
        public List<SidebarViewModel> GetSidebarLinks()
        {
            return service.GetAllSidebarLinks();
        }

        [HttpGet]
        [Route("{id}")]
        public CollectionViewModel Get(int id)
        {
            return service.GetCollectionsById(id);
        }
    }
}
