using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESS.Models
{
    public class MailContent
    {
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string  MailAttachments { get; set; }
    }
}
