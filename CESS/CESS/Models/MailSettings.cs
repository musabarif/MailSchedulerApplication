using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESS.Models
{
    public class MailSettings
    {
        public string ServerAddress { get; set; }
        public string ServerPort { get; set; }
        public bool UseSSL { get; set; }
        public string EncryptedConnectionPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mode { get; set; }
    }
}
