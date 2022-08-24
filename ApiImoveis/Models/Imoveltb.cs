using System;
using System.Collections.Generic;

#nullable disable

namespace ApiImoveis.Models
{
    public partial class Imoveltb
    {
        public int IdImovel { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Logradouro { get; set; }
        public sbyte? Alugado { get; set; }
    }
}
