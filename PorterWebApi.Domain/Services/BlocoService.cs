using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Repositories;
using PorterWebApi.Domain.Interfaces.Services;

namespace PorterWebApi.Domain.Services
{
    public class BlocoService : ServiceBase<Bloco>, IBlocoService
    {
        private readonly IBlocoRepository _blocoRepository;

        public BlocoService(IBlocoRepository blocoRepository)
            : base(blocoRepository)
        {
            _blocoRepository = blocoRepository;
        }
    }
}
