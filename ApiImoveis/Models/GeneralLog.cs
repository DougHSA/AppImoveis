using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class GeneralLog
    {
        public DateTime EventTime { get; set; }
        public string UserHost { get; set; }
        public ulong ThreadId { get; set; }
        public uint ServerId { get; set; }
        public string CommandType { get; set; }
        public byte[] Argument { get; set; }
    }
}
