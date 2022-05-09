using System.Collections.Generic;
using System.Linq;

namespace Portal.ViewModels
{
    public class ConsoleViewModel
    {
        public string ActiveEndpointUrl { get; set; }
        public List<ConsoleParam> ActiveEndpointParameters { get; set; }
        public Dictionary<string, string> ParamDictionary { get; set; }
        public string Jwt { get; set; }

        public void PopulateDictionary()
        {
            if (ParamDictionary == null)
            {
                ParamDictionary = new Dictionary<string, string>();
            }
            foreach (var param in ActiveEndpointParameters)
            {
                ParamDictionary.Add(param.Key, param.Value);
                if (param.Value == "")
                {
                    ParamDictionary.Remove(param.Key);
                }
            }
        }
    }

    public class ConsoleParam
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}