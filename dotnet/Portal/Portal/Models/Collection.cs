using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Collection
    {
        public Collection()
        {
            Endpoints = new HashSet<Endpoint>();
        }

        public int CollectionId { get; set; }
        public string CollectionName { get; set; }

        public virtual ICollection<Endpoint> Endpoints { get; set; }
    }
}
