using Portal.Models;
using Portal.ViewModels;

namespace Portal.Services
{
    public interface IEndpointService
    {
        public Endpoint EditEndpointDescription(EditEndpointDescriptionViewModel model);
        public EndpointViewModel GetEndpointById(int id);
    }
}
