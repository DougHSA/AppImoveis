using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class ProcsPriv
    {
        public string Host { get; set; }
        public string Db { get; set; }
        public string User { get; set; }
        public string RoutineName { get; set; }
        public string RoutineType { get; set; }
        public string Grantor { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
