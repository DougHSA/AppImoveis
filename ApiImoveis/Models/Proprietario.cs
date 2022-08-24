using System;
using System.Collections.Generic;

#nullable disable

namespace ApiImoveis.Models
{
    public partial class Proprietario
    {
        public int IdProprietario { get; set; }
        public long Cpf { get; set; }
        public int IdImovel { get; set; }
    }
}
