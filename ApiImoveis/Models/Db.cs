using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class Db
    {
        public string Host { get; set; }
        public string Db1 { get; set; }
        public string User { get; set; }
        public string SelectPriv { get; set; }
        public string InsertPriv { get; set; }
        public string UpdatePriv { get; set; }
        public string DeletePriv { get; set; }
        public string CreatePriv { get; set; }
        public string DropPriv { get; set; }
        public string GrantPriv { get; set; }
        public string ReferencesPriv { get; set; }
        public string IndexPriv { get; set; }
        public string AlterPriv { get; set; }
        public string CreateTmpTablePriv { get; set; }
        public string LockTablesPriv { get; set; }
        public string CreateViewPriv { get; set; }
        public string ShowViewPriv { get; set; }
        public string CreateRoutinePriv { get; set; }
        public string AlterRoutinePriv { get; set; }
        public string ExecutePriv { get; set; }
        public string EventPriv { get; set; }
        public string TriggerPriv { get; set; }
    }
}
