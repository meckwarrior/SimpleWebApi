using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Repositories;
using PorterWebApi.Domain.Interfaces.Services;

namespace PorterWebApi.Domain.Services
{
    public class CondominioService : ServiceBase<Condominio>, ICondominioService
    {
        private readonly ICondominioRepository _condominioRepository;

        public CondominioService(ICondominioRepository condominioRepository)
            : base (condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }

    }
}
