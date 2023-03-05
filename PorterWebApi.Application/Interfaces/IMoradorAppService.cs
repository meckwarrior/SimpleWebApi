using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Application.Interfaces
{
    public interface IMoradorAppService : IAppServiceBase<Morador>
    {
        void Delete(int id);
    }
}
