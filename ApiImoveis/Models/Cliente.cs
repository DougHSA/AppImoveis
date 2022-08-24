using System;
using System.Collections.Generic;

#nullable disable

namespace ApiImoveis.Models
{
    public partial class Cliente
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
