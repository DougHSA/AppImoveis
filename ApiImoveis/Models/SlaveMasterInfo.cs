using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class SlaveMasterInfo
    {
        public uint NumberOfLines { get; set; }
        public string MasterLogName { get; set; }
        public ulong MasterLogPos { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public uint Port { get; set; }
        public uint ConnectRetry { get; set; }
        public bool EnabledSsl { get; set; }
        public string SslCa { get; set; }
        public string SslCapath { get; set; }
        public string SslCert { get; set; }
        public string SslCipher { get; set; }
        public string SslKey { get; set; }
        public bool SslVerifyServerCert { get; set; }
        public float Heartbeat { get; set; }
        public string Bind { get; set; }
        public string IgnoredServerIds { get; set; }
        public string Uuid { get; set; }
        public ulong RetryCount { get; set; }
        public string SslCrl { get; set; }
        public string SslCrlpath { get; set; }
        public bool EnabledAutoPosition { get; set; }
        public string ChannelName { get; set; }
        public string TlsVersion { get; set; }
        public string PublicKeyPath { get; set; }
        public bool GetPublicKey { get; set; }
        public string NetworkNamespace { get; set; }
        public string MasterCompressionAlgorithm { get; set; }
        public uint MasterZstdCompressionLevel { get; set; }
        public string TlsCiphersuites { get; set; }
        public bool SourceConnectionAutoFailover { get; set; }
        public bool GtidOnly { get; set; }
    }
}
