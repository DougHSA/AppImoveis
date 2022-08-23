using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class User
    {
        public string Host { get; set; }
        public string User1 { get; set; }
        public string SelectPriv { get; set; }
        public string InsertPriv { get; set; }
        public string UpdatePriv { get; set; }
        public string DeletePriv { get; set; }
        public string CreatePriv { get; set; }
        public string DropPriv { get; set; }
        public string ReloadPriv { get; set; }
        public string ShutdownPriv { get; set; }
        public string ProcessPriv { get; set; }
        public string FilePriv { get; set; }
        public string GrantPriv { get; set; }
        public string ReferencesPriv { get; set; }
        public string IndexPriv { get; set; }
        public string AlterPriv { get; set; }
        public string ShowDbPriv { get; set; }
        public string SuperPriv { get; set; }
        public string CreateTmpTablePriv { get; set; }
        public string LockTablesPriv { get; set; }
        public string ExecutePriv { get; set; }
        public string ReplSlavePriv { get; set; }
        public string ReplClientPriv { get; set; }
        public string CreateViewPriv { get; set; }
        public string ShowViewPriv { get; set; }
        public string CreateRoutinePriv { get; set; }
        public string AlterRoutinePriv { get; set; }
        public string CreateUserPriv { get; set; }
        public string EventPriv { get; set; }
        public string TriggerPriv { get; set; }
        public string CreateTablespacePriv { get; set; }
        public string SslType { get; set; }
        public byte[] SslCipher { get; set; }
        public byte[] X509Issuer { get; set; }
        public byte[] X509Subject { get; set; }
        public uint MaxQuestions { get; set; }
        public uint MaxUpdates { get; set; }
        public uint MaxConnections { get; set; }
        public uint MaxUserConnections { get; set; }
        public string Plugin { get; set; }
        public string AuthenticationString { get; set; }
        public string PasswordExpired { get; set; }
        public DateTime? PasswordLastChanged { get; set; }
        public ushort? PasswordLifetime { get; set; }
        public string AccountLocked { get; set; }
        public string CreateRolePriv { get; set; }
        public string DropRolePriv { get; set; }
        public ushort? PasswordReuseHistory { get; set; }
        public ushort? PasswordReuseTime { get; set; }
        public string PasswordRequireCurrent { get; set; }
        public string UserAttributes { get; set; }
    }
}
