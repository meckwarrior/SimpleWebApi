using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Repositories;
using PorterWebApi.Domain.Interfaces.Services;

namespace PorterWebApi.Domain.Services
{
    public class MoradorService : ServiceBase<Morador>, IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;

        public MoradorService(IMoradorRepository moradorRepository)
            : base(moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }
    }
}
