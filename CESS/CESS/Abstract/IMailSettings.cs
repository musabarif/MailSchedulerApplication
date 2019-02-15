using CESS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESS.Abstract
{
    interface IMailSettings
    {
        bool SaveSettingsToFile(MailSettings mailSettings);
        bool ValidateSettings(MailSettings model);
        void SendShedulerMail(MailDirectory directory);
    }
}
