using Portal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Extensions
{
    public static class ApiJsonExtensions
    {
        public static Collection GetCollectionFromApiJson(this KeyValuePair<string, ApiJsonEndpoint> jsonCollection)
        {
            var collection = new Collection();
            var path = jsonCollection.Value;
            if (path.get != null)
                collection.CollectionName = path.get.tags.First();
            if (path.post != null)
                collection.CollectionName = path.post.tags.First();
            if (path.put != null)
                collection.CollectionName = path.put.tags.First();
            if (path.delete != null)
                collection.CollectionName = path.delete.tags.First();
            return collection;
        }

        public static Endpoint GetEndpointsFromApiJson(this ApiJsonMethod jsonEndpoint, string url)
        {
            var endpoint = new Endpoint();
            endpoint.EndpointName = jsonEndpoint.summary;
            endpoint.Urlsuffix = url;
            return endpoint;
        }
        
        public static List<Response> GetResponsesFromApiJson(this Dictionary<int, ApiJsonResponse> jsonResponses)
        {
            var responses = new List<Response>();
            foreach (var item in jsonResponses)
            {
                var response = new Response();
                response.StatusCode = item.Key;
                response.Description = item.Value.description;
                responses.Add(response);
            }
            return responses;
        }

        // *********
        public static SchemaReference GetSchemaReferencesFromApiJson(this ApiJson jsonSchemaReference)
        {
            var schemaReference = new SchemaReference();
            var schema = jsonSchemaReference.components.schemas.First();
            schemaReference.SchemaReferenceName = schema.Key;
            schemaReference.Jsonstring = schema.Value.ToString();
            return schemaReference;
        }

        #region Request Parameters
        //public static RequestParameter GetRequestParametersFromApiJson(this ApiJson jsonRequestParameter)
        //{
        //    var requestParameter = new RequestParameter();
        //    var path = jsonRequestParameter.paths.First().Value;
        //    if (path.get.parameters != null)
        //    {
        //        if (path.get.parameters.First().@in == "path")
        //            requestParameter.ParameterLocation = 1;
        //        if (path.get.parameters.First().@in == "query")
        //            requestParameter.ParameterLocation = 2;
        //        requestParameter.Required = path.get.parameters.First().schema.nullable;
        //    }
        //    else if (path.post.parameters != null)
        //    {
        //        if (path.post.parameters.First().@in == "path")
        //            requestParameter.ParameterLocation = 1;
        //        if (path.post.parameters.First().@in == "query")
        //            requestParameter.ParameterLocation = 2;
        //        requestParameter.Required = path.post.parameters.First().schema.nullable;
        //    }
        //    else if (path.put.parameters != null)
        //    {
        //        if (path.put.parameters.First().@in == "path")
        //            requestParameter.ParameterLocation = 1;
        //        if (path.put.parameters.First().@in == "query")
        //            requestParameter.ParameterLocation = 2;
        //        requestParameter.Required = path.put.parameters.First().schema.nullable;
        //    }
        //    else if (path.delete.parameters != null)
        //    {
        //        if (path.delete.parameters.First().@in == "path")
        //            requestParameter.ParameterLocation = 1;
        //        if (path.delete.parameters.First().@in == "query")
        //            requestParameter.ParameterLocation = 2;
        //        requestParameter.Required = path.delete.parameters.First().schema.nullable;
        //    }
        //    return requestParameter;
        //}
        #endregion

        public static Request GetParametersFromApiJson(this List<ApiJsonParameter> parameters, Request req)
        {
            foreach (var p in parameters)
            {
                var param = new Parameter();
                param.ParameterName = p.name;
                param.Required = !p.schema.nullable;
                param.Description = p.description;
                param.ParameterLocation = p.@in == "query" ? 1 : 2;
                param.Values = p.schema.type;

                if (req.Parameters == null)
                {
                    req.Parameters = new List<Parameter>();
                }
                req.Parameters.Add(param);
            }
            return req;
        }
    }
}