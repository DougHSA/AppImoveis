using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class TimeZoneTransition
    {
        public uint TimeZoneId { get; set; }
        public long TransitionTime { get; set; }
        public uint TransitionTypeId { get; set; }
    }
}
