using Portal.ViewModels;
using System.Threading.Tasks;

namespace Portal.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailFormViewModel vm);
    }
}
