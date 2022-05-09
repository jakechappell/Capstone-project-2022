using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class SchemaReference
    {
        public int SchemaReferenceId { get; set; }
        public string SchemaReferenceName { get; set; }
        public string Jsonstring { get; set; }
        public int ResponseId { get; set; }
        public int RequestId { get; set; }

        public virtual Request Request { get; set; }
        public virtual Response Response { get; set; }
    }
}
