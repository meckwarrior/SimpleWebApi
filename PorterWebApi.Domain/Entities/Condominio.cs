using System;

namespace PorterWebApi.Domain.Entities
{
    public class Condominio
    {
        public int CondominioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string EmailSindico { get; set; }
        public string TelefoneSindico { get; set; }
    }
}
