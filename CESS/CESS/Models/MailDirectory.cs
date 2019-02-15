using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESS.Models
{
    public class MailDirectory
    {
        public string PendingDirectory { get; set; }
        public string FinishedDirectory { get; set; }
        public string FailedDirectory { get; set; }
    }
}
