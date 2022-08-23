using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class GlobalGrant
    {
        public string User { get; set; }
        public string Host { get; set; }
        public string Priv { get; set; }
        public string WithGrantOption { get; set; }
    }
}
