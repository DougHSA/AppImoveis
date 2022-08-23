using System;
using System.Collections.Generic;

#nullable disable

namespace Imovel.Models
{
    public partial class PasswordHistory
    {
        public string Host { get; set; }
        public string User { get; set; }
        public DateTime PasswordTimestamp { get; set; }
        public string Password { get; set; }
    }
}
