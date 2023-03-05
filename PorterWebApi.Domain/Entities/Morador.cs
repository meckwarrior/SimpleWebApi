using System;

namespace PorterWebApi.Domain.Entities
{
    public class Morador
    {
        public int MoradorId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int ApartamentoId { get; set; }
    }
}
