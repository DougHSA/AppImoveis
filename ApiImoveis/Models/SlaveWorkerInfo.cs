using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class SlaveWorkerInfo
    {
        public uint Id { get; set; }
        public string RelayLogName { get; set; }
        public ulong RelayLogPos { get; set; }
        public string MasterLogName { get; set; }
        public ulong MasterLogPos { get; set; }
        public string CheckpointRelayLogName { get; set; }
        public ulong CheckpointRelayLogPos { get; set; }
        public string CheckpointMasterLogName { get; set; }
        public ulong CheckpointMasterLogPos { get; set; }
        public uint CheckpointSeqno { get; set; }
        public uint CheckpointGroupSize { get; set; }
        public byte[] CheckpointGroupBitmap { get; set; }
        public string ChannelName { get; set; }
    }
}
