using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class InnodbTableStat
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public DateTime LastUpdate { get; set; }
        public ulong NRows { get; set; }
        public ulong ClusteredIndexSize { get; set; }
        public ulong SumOfOtherIndexSizes { get; set; }
    }
}
