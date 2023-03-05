using System;

namespace PorterWebApi.Domain.Entities
{
    public class Bloco
    {
        public int BlocoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public int CondominioId { get; set; }
    }
}
