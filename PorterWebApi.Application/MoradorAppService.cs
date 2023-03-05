using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Services;
using System;

namespace PorterWebApi.Application
{
    public class MoradorAppService : AppServiceBase<Morador>, IMoradorAppService
    {
        private readonly IMoradorService _moradorService;

        public MoradorAppService(IMoradorService moradorService)
            : base(moradorService)
        {
            _moradorService = moradorService;
        }

        public void Delete(int id)
        {
            Morador morador = _moradorService.GetById(id);

            if (morador == null)
                throw new Exception("Id inexistente");

            _moradorService.Remove(morador);
        }
    }
}
