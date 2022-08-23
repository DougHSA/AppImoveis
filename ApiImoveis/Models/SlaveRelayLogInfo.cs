using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class SlaveRelayLogInfo
    {
        public uint NumberOfLines { get; set; }
        public string RelayLogName { get; set; }
        public ulong? RelayLogPos { get; set; }
        public string MasterLogName { get; set; }
        public ulong? MasterLogPos { get; set; }
        public int? SqlDelay { get; set; }
        public uint? NumberOfWorkers { get; set; }
        public uint? Id { get; set; }
        public string ChannelName { get; set; }
        public string PrivilegeChecksUsername { get; set; }
        public string PrivilegeChecksHostname { get; set; }
        public bool RequireRowFormat { get; set; }
        public string RequireTablePrimaryKeyCheck { get; set; }
        public string AssignGtidsToAnonymousTransactionsType { get; set; }
        public string AssignGtidsToAnonymousTransactionsValue { get; set; }
    }
}
