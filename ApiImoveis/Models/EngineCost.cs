using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class EngineCost
    {
        public string EngineName { get; set; }
        public int DeviceType { get; set; }
        public string CostName { get; set; }
        public float? CostValue { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Comment { get; set; }
        public float? DefaultValue { get; set; }
    }
}
