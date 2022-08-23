using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class ReplicationAsynchronousConnectionFailover
    {
        public string ChannelName { get; set; }
        public string Host { get; set; }
        public uint Port { get; set; }
        public string NetworkNamespace { get; set; }
        public byte Weight { get; set; }
        public string ManagedName { get; set; }
    }
}
