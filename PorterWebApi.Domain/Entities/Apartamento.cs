using System;

namespace PorterWebApi.Domain.Entities
{
    public class Apartamento
    {
        public int ApartamentoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Numero { get; set; }
        public int Andar { get; set; }
        public int BlocoId { get; set; }
}
}
