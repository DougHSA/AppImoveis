using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class TimeZoneTransitionType
    {
        public uint TimeZoneId { get; set; }
        public uint TransitionTypeId { get; set; }
        public int Offset { get; set; }
        public byte IsDst { get; set; }
        public string Abbreviation { get; set; }
    }
}
