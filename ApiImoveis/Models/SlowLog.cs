using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class SlowLog
    {
        public DateTime StartTime { get; set; }
        public string UserHost { get; set; }
        public TimeSpan QueryTime { get; set; }
        public TimeSpan LockTime { get; set; }
        public int RowsSent { get; set; }
        public int RowsExamined { get; set; }
        public string Db { get; set; }
        public int LastInsertId { get; set; }
        public int InsertId { get; set; }
        public uint ServerId { get; set; }
        public byte[] SqlText { get; set; }
        public ulong ThreadId { get; set; }
    }
}
