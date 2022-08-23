using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class RoleEdge
    {
        public string FromHost { get; set; }
        public string FromUser { get; set; }
        public string ToHost { get; set; }
        public string ToUser { get; set; }
        public string WithAdminOption { get; set; }
    }
}
