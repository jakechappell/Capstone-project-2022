using Microsoft.EntityFrameworkCore;
using Portal.Models;
using Portal.ViewModels;
using System;
using System.Linq;
using System.Net;

namespace Portal.Services
{
    public class EndpointService : IEndpointService
    {
        private CheetahDBContext context;
        public EndpointService(CheetahDBContext _context)
        {
            context = _context;
        }
        public Endpoint EditEndpointDescription(EditEndpointDescriptionViewModel model)
        {
            var endpoint = context.Endpoints.Where(x => x.EndpointId == model.EndpointId).FirstOrDefault();
            if (endpoint == null)
            {
                throw new Exception("NotFound");
            }
            if (model.Description != endpoint.Description)
            {
                endpoint.EditUser = model.EditUser;
                endpoint.EditDateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            }
            endpoint.Description = model.Description;
            context.SaveChanges();
            return endpoint;
        }

        public EndpointViewModel GetEndpointById(int id)
        {
            return context.Endpoints
                .Include(x => x.Responses)
                    .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Requests)
                    .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Requests)
                    .ThenInclude(x => x.Parameters)
                .Where(x => x.EndpointId == id)
                .Select(x => new EndpointViewModel(x)).FirstOrDefault();
        }
    }
}
