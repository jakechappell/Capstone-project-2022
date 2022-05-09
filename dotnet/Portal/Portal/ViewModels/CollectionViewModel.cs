using Portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Portal.ViewModels
{
    public class CollectionViewModel
    {
        public CollectionViewModel()
        {
            Endpoints = new List<EndpointViewModel>();
        }

        public CollectionViewModel(Collection collection)
        {
            CollectionId = collection.CollectionId;
            CollectionName = collection.CollectionName;
            if (collection.Endpoints.Any())
            {
                Endpoints = collection.Endpoints.Select(x => new EndpointViewModel(x)).ToList();
            }
            else
            {
                Endpoints = new List<EndpointViewModel>();
            }
        }

        public int CollectionId { get; set; }
        public string CollectionName { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; }
    }

    /* 
    AREAVIEWMODEL, just in case we ever need it:
        public AreaViewModel()
        {
            Endpoints = new List<EndpointViewModel>();
        }

        public AreaViewModel(Area area)
        {
            AreaId = area.AreaId;
            Name = area.Name;
            Description = area.Description;
            Featured = area.Featured;
            DisplayOrder = area.DisplayOrder;
            if (area.Endpoints.Any())
            {
                Endpoints = area.Endpoints.Select(x => new EndpointViewModel(x)).ToList();
            }
            else
            {
                Endpoints = new List<EndpointViewModel>();
            }
        }

        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public int DisplayOrder { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; }
    }
     */
}
