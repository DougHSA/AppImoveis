using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class ReplicationAsynchronousConnectionFailoverManaged
    {
        public string ChannelName { get; set; }
        public string ManagedName { get; set; }
        public string ManagedType { get; set; }
        public string Configuration { get; set; }
    }
}
