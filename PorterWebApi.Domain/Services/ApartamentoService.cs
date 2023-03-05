using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Repositories;
using PorterWebApi.Domain.Interfaces.Services;

namespace PorterWebApi.Domain.Services
{
    public class ApartamentoService : ServiceBase<Apartamento>, IApartamentoService
    {
        private readonly IApartamentoRepository _apartamentoRepository;

        public ApartamentoService(IApartamentoRepository apartamentoRepository)
            : base (apartamentoRepository)
        {
            _apartamentoRepository = apartamentoRepository;
        }

    }
}
