using Newtonsoft.Json;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class ApiJson
    {
        public ApiJson()
        {
            
        }

        public string openapi;
        public object info;
        public Dictionary<string, ApiJsonEndpoint> paths; // UrlSuffix (Endpoints)
        public ApiJsonComponents components;
    }

    public class ApiJsonEndpoint
    {
        // Type (Requests)
        public ApiJsonMethod get;
        public ApiJsonMethod post;
        public ApiJsonMethod put;
        public ApiJsonMethod delete;
    }

    public class ApiJsonMethod
    {
        public List<string> tags; // CollectionName (Collections)
        public string summary; // EndpointName (Endpoints)
        public List<ApiJsonParameter> parameters;
        public Dictionary<int, ApiJsonResponse> responses;
        public ApiJsonRequestBody requestBody;
    }

    public class ApiJsonRequestBody
    {
        public string description;
        public Dictionary<string, ApiJsonContent> content;
    }

    public class ApiJsonParameter
    {
        public string name; // ParameterName (Parameters)
        public string @in; // ParameterLocation (Parameters)
        public string description; // Description (Parameter)
        public ApiJsonParameterSchema schema;
    }

    public class ApiJsonParameterSchema
    {
        public string type;
        public string description; // Description (Parameters)
        public string format;
        public bool nullable; // Required (RequestParameters)
    }

    public class ApiJsonResponse
    {
        public string description;
        public Dictionary<string, ApiJsonContent> content;
    }

    public class ApiJsonContent
    {
        public ApiJsonResponseSchema schema;
    }

    public class ApiJsonResponseSchema
    {
        public string type;

        [JsonProperty("$ref")]
        public string schemaRef;

        public ApiJsonSchemaRef items;
    }

    public class ApiJsonComponents
    {
        public Dictionary<string, ApiJsonSchema> schemas;
    }

    public class ApiJsonSchema
    {
        public string type;
        public List<string> required;
        public List<string> @enum;
        public Dictionary<string, ApiJsonSchemaProperty> properties;
    }

    public class ApiJsonSchemaProperty
    {
        public string type;
        public string description;
        public string format;
        public int minLength;
        public int maxLength;
        public int minimum;
        public int maximum;
        public bool nullable;
        public bool readOnly;
        public object additionalProperties; // how to deal with this being different things sometimes?

        [JsonProperty("$ref")]
        public string schemaRef;

        public ApiJsonSchemaRef items;
    }

    public class ApiJsonSchemaRef
    {
        [JsonProperty("$ref")]
        public string schemaRef;
    }
}
