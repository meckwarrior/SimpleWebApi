using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Application.Interfaces
{
    public interface IApartamentoAppService : IAppServiceBase<Apartamento>
    {
        void Delete(int id);
    }
}
