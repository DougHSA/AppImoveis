using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class TimeZoneLeapSecond
    {
        public long TransitionTime { get; set; }
        public int Correction { get; set; }
    }
}
