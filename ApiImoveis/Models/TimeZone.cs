using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class TimeZone
    {
        public uint TimeZoneId { get; set; }
        public string UseLeapSeconds { get; set; }
    }
}
