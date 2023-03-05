using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using PorterWebApi.Domain.Interfaces.Services;
using System;

namespace PorterWebApi.Application
{
    public class CondominioAppService : AppServiceBase<Condominio>, ICondominioAppService
    {
        private readonly ICondominioService _condominioService;

        public CondominioAppService(ICondominioService condominioService)
            : base(condominioService)
        {
            _condominioService = condominioService;
        }

        public void Delete(int id)
        {
            Condominio condominio = _condominioService.GetById(id);

            if (condominio == null)
                throw new Exception("Id inexistente");

            _condominioService.Remove(condominio);
        }
    }
}
