using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Application.Interfaces
{
    public interface ICondominioAppService : IAppServiceBase<Condominio>
    {
        void Delete(int id);
    }
}
