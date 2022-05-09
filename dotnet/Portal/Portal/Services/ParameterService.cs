using Portal.Models;
using Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Services
{
    public class ParameterService : IParameterService
    {
        private CheetahDBContext context;
        public ParameterService(CheetahDBContext _context)
        {
            context = _context;
        }
        public Parameter EditParameterDescription(EditParameterDescriptionViewModel model, string key)
        {
            var id = Convert.ToInt32(key);
            var parameter = context.Parameters.Where(x => x.ParameterId == id).FirstOrDefault();
            if (parameter == null)
            {
                throw new Exception("Not Found");
            }
            if (model.ParameterEditsDictionary[key] != parameter.Description)
            {
                parameter.EditUser = model.EditUser;
                parameter.EditDateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            }
            parameter.Description = model.ParameterEditsDictionary[key];
            context.SaveChanges();
            return parameter;
        }
    }
}
