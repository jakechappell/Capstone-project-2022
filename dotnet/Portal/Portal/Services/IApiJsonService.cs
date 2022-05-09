
using Portal.Models;

namespace Portal.Services
{
    public interface IApiJsonService
    {
        ApiJson GetApiJson();
        void SaveData(ApiJson data);
    }
}
