using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Services;
using System;

namespace PorterWebApi.Application
{
    public class BlocoAppService : AppServiceBase<Bloco>, IBlocoAppService
    {
        private readonly IBlocoService _blocoService;

        public BlocoAppService(IBlocoService blocoService)
            : base(blocoService)
        {
            _blocoService = blocoService;
        }

        public void Delete(int id)
        {
            Bloco bloco = _blocoService.GetById(id);

            if (bloco == null)
                throw new Exception("Id inexistente");

            _blocoService.Remove(bloco);
        }
    }
}
