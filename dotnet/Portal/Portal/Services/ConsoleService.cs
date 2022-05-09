using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portal.Models;
using Portal.ViewModels;

namespace Portal.Services
{
    public class ConsoleService : IConsoleService
    {
        public readonly IConfiguration config;
        public ConsoleService(IConfiguration _config)
        {
            config = _config;
        }
        public async Task<IEnumerable<dynamic>> MakeConsoleCall(ConsoleViewModel model)
        {
            try
            {
                model.PopulateDictionary();

                var section = config.GetSection("RootURL");
                var rootUrl = section["Url"];

                if (model.ParamDictionary.Count != 0)
                {
                    var response = await rootUrl.AppendPathSegment(model.ActiveEndpointUrl)
                        .SetQueryParams(model.ParamDictionary)
                        .WithHeader("Content-Type", "application/json")
                        .WithOAuthBearerToken(model.Jwt).GetJsonListAsync();
                    
                    Console.WriteLine("done with call");
                    return response;
                }
                else
                {
                    var response = await rootUrl.AppendPathSegment(model.ActiveEndpointUrl)
                        .WithHeader("Content-Type", "application/json")
                        .WithOAuthBearerToken(model.Jwt).GetJsonListAsync();
                    
                    Console.WriteLine("done with call");

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                if (ex.Message.Contains("401"))
                {
                    return new[] {"Unauthorized. Check your Cheetah API access status"};
                }
                if (ex.Message.Contains("503"))
                {
                    return new[] {"Cannot communicate with Accutech servers. Please try again later."};
                }
                if (ex.Message.Contains("Response could not be deserialized to JSON"))
                {
                    return new[] {"Endpoint unavailable for testing."};
                }
                return new[] {"Bad Request. Try again with different values"};
            }
        }
        
        public async Task<dynamic> MakeConsoleCall_Dynamic(ConsoleViewModel model)
        {
            try
            {
                model.PopulateDictionary();

                var section = config.GetSection("RootURL");
                var rootUrl = section["Url"];

                if (model.ParamDictionary.Count != 0)
                {
                    var response = await rootUrl.AppendPathSegment(model.ActiveEndpointUrl)
                        .SetQueryParams(model.ParamDictionary)
                        .WithHeader("Content-Type", "application/json")
                        .WithOAuthBearerToken(model.Jwt).GetJsonAsync();
                    
                    Console.WriteLine("done with call");
                    return response;
                }
                else
                {
                    var response = await rootUrl.AppendPathSegment(model.ActiveEndpointUrl)
                        .WithHeader("Content-Type", "application/json")
                        .WithOAuthBearerToken(model.Jwt).GetJsonAsync();
                    
                    Console.WriteLine("done with call");

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                if (ex.Message.Contains("401"))
                {
                    return "Unauthorized. Check your Cheetah API access.";
                }
                if (ex.Message.Contains("503"))
                {
                    return "Unable to communicate with Accutech. Please try again later.";
                }
                if (ex.Message.Contains("Response could not be deserialized to JSON"))
                {
                    return "Retry...";
                }
                return "Bad request. Please try again with different values";
            }
        }
    }
}