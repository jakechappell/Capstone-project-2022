using Portal.Models;
using System.Collections.Generic;

namespace Portal.ViewModels
{
    public class SchemaRefViewModel
    {
        public int SchemaReferenceId { get; set; }
        public string SchemaName { get; set; }
        public List<SchemaRefDetails> SchemaRefDetails { get; set; }

    }
    public class SchemaRefDetails
    {
        public int SchemaReferenceDetailId { get; set; }
        public int SchemaReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public List<string> Required { get; set; }
        public List<string> EnumValues { get; set; }
        public Dictionary<string, ApiJsonSchemaProperty> Properties { get; set; }
    }
}
