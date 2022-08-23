using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class Component
    {
        public uint ComponentId { get; set; }
        public uint ComponentGroupId { get; set; }
        public string ComponentUrn { get; set; }
    }
}
