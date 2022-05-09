using Portal.Models;
using Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Services
{
    public interface IParameterService
    {
        public Parameter EditParameterDescription(EditParameterDescriptionViewModel model, string key);
    }
}
