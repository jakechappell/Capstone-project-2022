using Microsoft.Extensions.Configuration;
using System;
using Flurl.Http;
using System.Threading.Tasks;
using Portal.Models;
using Newtonsoft.Json;
using Portal.Extensions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Portal.Services
{
    public class ApiJsonService : IApiJsonService
    {
        private CheetahDBContext context;
        public readonly IConfiguration config;
        public ApiJsonService(IConfiguration _config, CheetahDBContext ctx)
        {
            config = _config;
            context = ctx;
        }
        public ApiJson GetApiJson()
        {
            var pathSection = config.GetSection("RootURL");
            var loginSection = config.GetSection("LoginInfo");
            var jsonUrl = pathSection["JsonUrl"];
            var loginJwt = loginSection["Jwt"];
            var settings = new JsonSerializerSettings();
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;

            try
            {
                var jsonString = GetJsonString(jsonUrl, loginJwt).Result;
                var result = JsonConvert
                    .DeserializeObject<ApiJson>(jsonString, settings);

                //Console.WriteLine("JSON: " + result.paths["/api/v6/Accounts"].post.responses[200].content["text/plain"].schema.schemaRef);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //Console.WriteLine("Make sure the user is logged in!");
                //Probably not needed because the user doesn't need to be logged in
                return null;
            }
        }
        private async Task<string> GetJsonString(string jsonUrl, string loginJwt)
        {
            var swagger_json = await jsonUrl.WithOAuthBearerToken(loginJwt).GetStringAsync();
            return swagger_json;
        }
        public void SaveData(ApiJson data)
        {
            #region Schema References
            //foreach (var schema in data.components.schemas)
            //{
            //    var sRef = new SchemaReference();
            //    sRef.SchemaReferenceName = schema.Key;
            //    if (schema.Value.type != null) 
            //    { 
            //        sRef
            //    }
            //}
            #endregion

            #region Data Saver
            var parameters = context.Parameters.ToList();
            context.Parameters.RemoveRange(parameters);
            var requests = context.Requests.ToList();
            context.Requests.RemoveRange(requests);
            var responses = context.Responses.ToList();
            context.Responses.RemoveRange(responses);
            var endpoints = context.Endpoints.ToList();
            context.Endpoints.RemoveRange(endpoints);
            var collections = context.Collections.ToList();
            context.Collections.RemoveRange(collections);

            context.SaveChanges();

            var dbCollections = new List<Collection>();
            foreach (var item in data.paths)
            {
                var collection = item.GetCollectionFromApiJson();
                if (!dbCollections.Any(x => x.CollectionName == collection.CollectionName))
                {
                    dbCollections.Add(collection);
                }
            }

            foreach (var item in data.paths)
            {
                var coll = item.GetCollectionFromApiJson();
                var collection = dbCollections.Where(x => x.CollectionName == coll.CollectionName).First();

                if (item.Value.get != null)
                {
                    if (collection.Endpoints == null)
                        collection.Endpoints = new List<Endpoint>();
                    var ep = item.Value.get.GetEndpointsFromApiJson(item.Key);

                    ep.Responses = item.Value.get.responses.GetResponsesFromApiJson();

                    var req = new Request() { Type = 1 };
                    if (ep.Requests == null)
                        ep.Requests = new List<Request>();

                    if (item.Value.get.parameters != null)
                        req = item.Value.get.parameters.GetParametersFromApiJson(req);

                    ep.Requests.Add(req);
                    collection.Endpoints.Add(ep);
                }
                if (item.Value.post != null)
                {
                    if (collection.Endpoints == null)
                        collection.Endpoints = new List<Endpoint>();
                    var ep = item.Value.post.GetEndpointsFromApiJson(item.Key);

                    ep.Responses = item.Value.post.responses.GetResponsesFromApiJson();

                    var req = new Request() { Type = 2 };
                    if (ep.Requests == null)
                        ep.Requests = new List<Request>();

                    if (item.Value.post.parameters != null)
                        req = item.Value.post.parameters.GetParametersFromApiJson(req);

                    ep.Requests.Add(req);
                    collection.Endpoints.Add(ep);
                }
                if (item.Value.put != null)
                {
                    if (collection.Endpoints == null)
                        collection.Endpoints = new List<Endpoint>();
                    var ep = item.Value.put.GetEndpointsFromApiJson(item.Key);

                    ep.Responses = item.Value.put.responses.GetResponsesFromApiJson();

                    var req = new Request() { Type = 3 };
                    if (ep.Requests == null)
                        ep.Requests = new List<Request>();

                    if (item.Value.put.parameters != null)
                        req = item.Value.put.parameters.GetParametersFromApiJson(req);

                    ep.Requests.Add(req);
                    collection.Endpoints.Add(ep);
                }
                if (item.Value.delete != null)
                {
                    if (collection.Endpoints == null)
                        collection.Endpoints = new List<Endpoint>();
                    var ep = item.Value.delete.GetEndpointsFromApiJson(item.Key);

                    ep.Responses = item.Value.delete.responses.GetResponsesFromApiJson();

                    var req = new Request() { Type = 4 };
                    if (ep.Requests == null)
                        ep.Requests = new List<Request>();

                    if (item.Value.delete.parameters != null)
                        req = item.Value.delete.parameters.GetParametersFromApiJson(req);

                    ep.Requests.Add(req);
                    collection.Endpoints.Add(ep);
                }

                context.Add(collection);
            }

            if (!parameters.IsNullOrEmpty())
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Parameters', RESEED, 0)");
            }
            if (!requests.IsNullOrEmpty())
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Requests', RESEED, 0)");
            }
            if (!responses.IsNullOrEmpty())
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Responses', RESEED, 0)");
            }
            if (!endpoints.IsNullOrEmpty())
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Endpoints', RESEED, 0)");
            }
            if (!collections.IsNullOrEmpty())
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Collections', RESEED, 0)");
            }
            context.SaveChanges();
            #endregion

            //var schemaReference = data.GetSchemaReferencesFromApiJson();
        }
    }
}