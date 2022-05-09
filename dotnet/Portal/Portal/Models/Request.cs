using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Request
    {
        public Request()
        {
            Parameters = new HashSet<Parameter>();
            SchemaReferences = new HashSet<SchemaReference>();
        }

        public int RequestId { get; set; }
        public int EndpointId { get; set; }
        public int Type { get; set; }

        public virtual Endpoint Endpoint { get; set; }
        public virtual ICollection<Parameter> Parameters { get; set; }
        public virtual ICollection<SchemaReference> SchemaReferences { get; set; }
    }
}
