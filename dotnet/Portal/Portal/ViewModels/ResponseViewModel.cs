using Portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Portal.ViewModels
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            SchemaReferences = new List<SchemaReferenceViewModel>();
        }

        public ResponseViewModel(Response response)
        {
            ResponseId = response.ResponseId;
            StatusCode = response.StatusCode;
            Description = response.Description;
            EndpointId = response.EndpointId;
            ExampleValue = response.ExampleValue;

            if (response.SchemaReferences.Any())
            {
                SchemaReferences = response.SchemaReferences.Select(x => new SchemaReferenceViewModel(x)).ToList();
            }
        }

        public int ResponseId { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public int EndpointId { get; set; }
        public string ExampleValue { get; set; }

        public List<SchemaReferenceViewModel> SchemaReferences { get; set; }
    }
}
