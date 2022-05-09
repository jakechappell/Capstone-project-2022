using System.Collections.Generic;

namespace Portal.ViewModels
{
    public class SidebarViewModel
    {
        public int CollectionId { get; set; }
        public string CollectionName { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; }
    }
}
