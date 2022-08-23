using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class ProxiesPriv
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string ProxiedHost { get; set; }
        public string ProxiedUser { get; set; }
        public bool WithGrant { get; set; }
        public string Grantor { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
