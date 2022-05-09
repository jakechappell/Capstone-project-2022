using Microsoft.EntityFrameworkCore;
using Portal.Models;
using Portal.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Services
{
    public class CollectionService : ICollectionService
    {
        private CheetahDBContext context;
        public CollectionService(CheetahDBContext ctx)
        {
            context = ctx;
        }

        public List<CollectionViewModel> GetAllCollections()
        {
            return context.Collections
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Responses)
                        .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Requests)
                        .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Requests)
                        .ThenInclude(x => x.Parameters)
                .ToList()
                .Select(x => new CollectionViewModel(x)).ToList();
        }

        public List<SidebarViewModel> GetAllSidebarLinks()
        {
            return context.Collections.Select(x => new SidebarViewModel()
            {
                CollectionId = x.CollectionId,
                CollectionName = x.CollectionName,
                Endpoints = (List<EndpointViewModel>)context.Endpoints.Where(y => y.CollectionId == x.CollectionId)
                    .Select(y => new EndpointViewModel()
                    {
                        EndpointId = y.EndpointId,
                        EndpointName = y.EndpointName,
                        Urlsuffix = y.Urlsuffix,
                        Description = y.Description,
                        CollectionId = y.CollectionId,
                        Requests = y.Requests.Select(x => new RequestViewModel(x)).ToList(),
                        Responses = y.Responses.Select(x => new ResponseViewModel(x)).ToList()
                    }).OrderBy(x => x.Urlsuffix)
            }).OrderBy(x => x.CollectionName).ToList();
        }

        public CollectionViewModel GetCollectionsById(int id)
        {
            return context.Collections
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Responses)
                        .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Requests)
                        .ThenInclude(x => x.SchemaReferences)
                .Include(x => x.Endpoints)
                    .ThenInclude(x => x.Requests)
                       .ThenInclude(x => x.Parameters)
                .Where(x => x.CollectionId == id)
                .Select(x => new CollectionViewModel(x)).FirstOrDefault();
        }
    }
}
