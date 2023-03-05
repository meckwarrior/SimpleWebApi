using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Services;
using System;

namespace PorterWebApi.Application
{
    public class ApartamentoAppService : AppServiceBase<Apartamento>, IApartamentoAppService
    {
        private readonly IApartamentoService _apartamentoService;

        public ApartamentoAppService(IApartamentoService apartamentoService)
            : base(apartamentoService)
        {
            _apartamentoService = apartamentoService;
        }

        public void Delete(int id)
        {
            Apartamento apartamento = _apartamentoService.GetById(id);

            if (apartamento == null)
                throw new Exception("Id inexistente");

            _apartamentoService.Remove(apartamento);
        }
    }
}
