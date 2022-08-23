using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class ReplicationGroupMemberAction
    {
        public string Name { get; set; }
        public string Event { get; set; }
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public byte Priority { get; set; }
        public string ErrorHandling { get; set; }
    }
}
