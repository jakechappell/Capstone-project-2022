using System;
using Portal.Models;
using System.Collections.Generic;

namespace Portal.ViewModels
{
    public class ParameterViewModel
    {
        public ParameterViewModel()
        {}
        public ParameterViewModel(Parameter parameter)
        {
            ParameterId = parameter.ParameterId;
            ParameterName = parameter.ParameterName;
            Values = parameter.Values;
            Description = parameter.Description;
            Required = parameter.Required;
            ParameterLocation = parameter.ParameterLocation;
            RequestId = parameter.RequestId;
            EditDateTime = parameter.EditDateTime;
            EditUser = parameter.EditUser;
        }

        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string Values { get; set; }
        public string Description { get; set; }
        public bool? Required { get; set; }
        public int ParameterLocation { get; set; }
        public int RequestId { get; set; }
        public string EditDateTime { get; set; }
        public string EditUser { get; set; }
    }

    public class EditParameterDescriptionViewModel
    {
        public List<Param> ParameterEdits { get; set; }
        public Dictionary<string, string> ParameterEditsDictionary { get; set; }
        public string EditUser { get; set; }
        public void FillParamDictionary()
        {
            if (ParameterEditsDictionary == null)
            {
                ParameterEditsDictionary = new Dictionary<string, string>();
            }
            foreach(var p in ParameterEdits)
            {
                ParameterEditsDictionary.Add(p.Key, p.Value);
                if (p.Value == "")
                {
                    ParameterEditsDictionary.Remove(p.Key);
                }
            }
        }
    }

    public class Param
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
