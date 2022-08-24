using System;
using System.Collections.Generic;

#nullable disable

namespace ApiImoveis.Models
{
    public partial class Locacao
    {
        public int IdLocacao { get; set; }
        public int Cpflocatario { get; set; }
        public int IdImovel { get; set; }
    }
}
