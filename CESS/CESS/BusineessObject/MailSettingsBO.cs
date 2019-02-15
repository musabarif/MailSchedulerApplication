using CESS.Abstract;
using CESS.DataAcessObject;
using CESS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESS.BusineessObject
{
    public class MailSettingsBO
    {
        private IMailSettings mailsettingDAO;

        public MailSettingsBO()
        {
            mailsettingDAO = new MailSettingsDAO();
        }

        public bool SaveSettings(MailSettings model)
        {
            if(ValidateModel(model))
            {
                SaveSettingsToFile(model);
            }
            return true;
        }

        public bool ValidateSettings(MailSettings model)
        {
            return mailsettingDAO.ValidateSettings(model);
            
        }

        public bool ValidateModel(MailSettings model)
        {
            IsServerAddress(model.ServerAddress);
            return true;
        }

        public void SendShedulerMail(MailDirectory directory)
        {
            mailsettingDAO.SendShedulerMail(directory);
        }

        public  bool IsServerAddress(string serverAddress)
        {
            return true;
            throw new NotImplementedException("Create test First");
        }

        public void SaveSettingsToFile(MailSettings model)
        {
            mailsettingDAO.SaveSettingsToFile(model);
        }

    }
}
