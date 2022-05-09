using Portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Portal.ViewModels
{
    public class RequestViewModel
    {
        public RequestViewModel()
        {
            Parameters = new List<ParameterViewModel>();
            SchemaReferences = new List<SchemaReferenceViewModel>();
        }

        public RequestViewModel(Request request)
        {
            RequestId = request.RequestId;
            EndpointId = request.EndpointId;
            Type = request.Type;

            if (request.Parameters.Any())
            {
                Parameters = request.Parameters.Select(x => new ParameterViewModel(x)).ToList();
            }

            if (request.SchemaReferences.Any())
            {
                SchemaReferences = request.SchemaReferences.Select(x => new SchemaReferenceViewModel(x)).ToList();
            }
        }

        public int RequestId { get; set; }
        public int EndpointId { get; set; }
        public int Type { get; set; }

        public List<ParameterViewModel> Parameters { get; set; }
        public List<SchemaReferenceViewModel> SchemaReferences { get; set; }
    }

    public enum Type
    {
        Get = 1,
        Post,
        Put,
        Delete
    }
}
