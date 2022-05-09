using System;
using Portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Portal.ViewModels
{
    public class EndpointViewModel
    {
        public EndpointViewModel()
        {
            Requests = new List<RequestViewModel>();
            Responses = new List<ResponseViewModel>();
        }

        public EndpointViewModel(Endpoint endpoint)
        {
            EndpointId = endpoint.EndpointId;
            EndpointName = endpoint.EndpointName;
            Urlsuffix = endpoint.Urlsuffix;
            Description = endpoint.Description;
            CollectionId = endpoint.CollectionId;
            EditUser = endpoint.EditUser;
            EditDateTime = endpoint.EditDateTime;


            if (endpoint.Requests.Any())
            {
                Requests = endpoint.Requests.Select(x => new RequestViewModel(x)).ToList();
            }

            if (endpoint.Responses.Any())
            {
                Responses = endpoint.Responses.Select(x => new ResponseViewModel(x)).ToList();
            }
        }

        public int EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string Urlsuffix { get; set; }
        public string Description { get; set; }
        public int CollectionId { get; set; }
        public string EditUser { get; set; }
        public string EditDateTime { get; set; }

        public List<RequestViewModel> Requests { get; set; }
        public List<ResponseViewModel> Responses { get; set; }
    }

    public class EditEndpointDescriptionViewModel
    {
        public int EndpointId { get; set; }
        public string Description { get; set; }
        public string EditUser { get; set; }
    }

}
