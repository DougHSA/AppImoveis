using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class Server
    {
        public string ServerName { get; set; }
        public string Host { get; set; }
        public string Db { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Socket { get; set; }
        public string Wrapper { get; set; }
        public string Owner { get; set; }
    }
}
