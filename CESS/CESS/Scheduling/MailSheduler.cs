using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using CESS.BusineessObject;
using CESS.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppWithScheduler.Code
{
    
    public class MailSheduler : IScheduledTask
    {
        public string Schedule => "*/1 * * * *";

        private MailSettingsBO mailSettingsBO=new MailSettingsBO();
        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            MailDirectory directory = GetDirectory();
             mailSettingsBO.SendShedulerMail(directory);
            
        }

        private MailDirectory GetDirectory()
        {
            XDocument doc = XDocument.Load(@"C:\Users\musabarif\Documents\Visual Studio 2017\Projects\CESS\CESS\Settings\AppSettings.xml");
            string pendingDirectory = doc.Descendants("LOTSPendingDirectory").FirstOrDefault().Value;
            string FinishedDirectory = doc.Descendants("LOTSCompletedDirectory").FirstOrDefault().Value;
            string FailedDirectory = doc.Descendants("LOTSFailedDirectory").FirstOrDefault().Value;

            MailDirectory directory = new MailDirectory();
            directory.PendingDirectory = pendingDirectory;
            directory.FinishedDirectory = FinishedDirectory;
            directory.FailedDirectory = FailedDirectory;

            return directory;
        }
       
    }
    
   
}