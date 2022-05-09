using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.ViewModels;

namespace Portal.Services
{
    public interface IConsoleService
    {
        Task<IEnumerable<dynamic>> MakeConsoleCall(ConsoleViewModel model);
        Task<dynamic> MakeConsoleCall_Dynamic(ConsoleViewModel model);
    }
}