using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Response
    {
        public Response()
        {
            SchemaReferences = new HashSet<SchemaReference>();
        }

        public int ResponseId { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public int EndpointId { get; set; }
        public string ExampleValue { get; set; }

        public virtual Endpoint Endpoint { get; set; }
        public virtual ICollection<SchemaReference> SchemaReferences { get; set; }
    }
}
