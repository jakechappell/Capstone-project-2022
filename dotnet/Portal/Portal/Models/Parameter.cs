using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Parameter
    {
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string Values { get; set; }
        public string Description { get; set; }
        public bool? Required { get; set; }
        public int ParameterLocation { get; set; }
        public int RequestId { get; set; }
        public string EditUser { get; set; }
        public string EditDateTime { get; set; }

        public virtual Request Request { get; set; }
    }
}
