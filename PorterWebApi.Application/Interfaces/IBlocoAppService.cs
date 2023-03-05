using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Application.Interfaces
{
    public interface IBlocoAppService : IAppServiceBase<Bloco>
    {
        void Delete(int id);
    }
}
