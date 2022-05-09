using Portal.Models;

namespace Portal.ViewModels
{
    public class SchemaReferenceViewModel
    {
        public SchemaReferenceViewModel()
        {}

        public SchemaReferenceViewModel(SchemaReference schemaReference)
        {
            SchemaReferenceId = schemaReference.SchemaReferenceId;
            SchemaReferenceName = schemaReference.SchemaReferenceName;
            Jsonstring = schemaReference.Jsonstring;
            ResponseId = schemaReference.ResponseId;
            RequestId = schemaReference.RequestId;
        }
        
        public int SchemaReferenceId { get; set; }
        public string SchemaReferenceName { get; set; }
        public string Jsonstring { get; set; }
        public int ResponseId { get; set; }
        public int RequestId { get; set; }
    }
}
