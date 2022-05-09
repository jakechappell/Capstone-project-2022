using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Endpoint
    {
        public Endpoint()
        {
            Requests = new HashSet<Request>();
            Responses = new HashSet<Response>();
        }

        public int EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string Urlsuffix { get; set; }
        public string Description { get; set; }
        public int CollectionId { get; set; }
        public string EditUser { get; set; }
        public string EditDateTime { get; set; }

        public virtual Collection Collection { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
