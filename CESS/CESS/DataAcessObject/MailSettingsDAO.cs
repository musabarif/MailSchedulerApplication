using CESS.Models;
using CESS.Abstract;
using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

namespace CESS.DataAcessObject
{
    public class MailSettingsDAO:IMailSettings
    {

        public bool SaveSettingsToFile(MailSettings mailSettings) 
        {
            using (XmlWriter writer = XmlWriter.Create(@"D:\LOTS\Email\MailSettings\SMTPsettings.xml"))
            {
                writer.WriteStartElement("SMTPSetting");
                writer.WriteElementString("OutgoingServerAddress", mailSettings.ServerAddress);
                writer.WriteElementString("OutgoingServerPort", mailSettings.ServerPort);
                writer.WriteElementString("IsSSL",mailSettings.UseSSL.ToString());
                writer.WriteElementString("EncryptedConnectionPort",mailSettings.EncryptedConnectionPort);
                writer.WriteElementString("UserName", mailSettings.Username);
                writer.WriteElementString("Password", mailSettings.Password);
                writer.WriteElementString("Mode", mailSettings.Mode);
                writer.WriteEndElement();
                writer.Flush();
            }
            return true;
        }

        public bool ValidateSettings(MailSettings model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                MailContent mailContent = new MailContent();
                mailContent.MailTo = "musabarif.arif2@gmail.com";
                mailContent.MailSubject = "Testing CESS";
                mailContent.MailBody = "Teting if mail settings are working fine!.";
                SendMail(mailContent, model);
            }
            return true;
        }

        public void SendShedulerMail(MailDirectory directory)
        {
            DirectoryInfo d = new DirectoryInfo(directory.PendingDirectory);
            FileInfo[] Files = d.GetFiles("*.xml");
            foreach (FileInfo file in Files)
            {

                try
                {
                    if (FetchInfoAndSendMail(file))
                    {
                        MoveFile(file, directory.FinishedDirectory);
                    }
                    else
                    {
                        MoveFile(file, directory.FailedDirectory);
                    }
                }
                catch (Exception)
                {
                    MoveFile(file, directory.FailedDirectory);
                    throw;
                }
                
            }
            
        }

        private void MoveFile(FileInfo file, string destinationDirectory)
        {
            File.Move(file.FullName, destinationDirectory+file.Name);
        }

        private bool FetchInfoAndSendMail(FileInfo file)
        {
            MailContent mailContent = FetchMailContent(file);
            MailSettings mailSettings = FetchMailSettings();
            return SendMail(mailContent,mailSettings);
        }

        private MailSettings FetchMailSettings()
        {
            MailSettings mailSettings = new MailSettings();
            XDocument doc = XDocument.Load(@"D:\LOTS\Email\MailSettings\SMTPsettings.xml");
            string serverAddress = doc.Descendants("OutgoingServerAddress").FirstOrDefault().Value;
            string serverPort = doc.Descendants("OutgoingServerPort").FirstOrDefault().Value;
            string userName = doc.Descendants("UserName").FirstOrDefault().Value;
            string password = doc.Descendants("Password").FirstOrDefault().Value;
            mailSettings.ServerAddress = serverAddress;
            mailSettings.ServerPort = serverPort;
            mailSettings.Username = userName;
            mailSettings.Password = password;
            return mailSettings;
        }

        private bool SendMail(MailContent mailContent,MailSettings mailSettings)
        {
            int serverPort = 0;
            Int32.TryParse(mailSettings.ServerPort, out serverPort);
            var client = new SmtpClient(mailSettings.ServerAddress, serverPort)
            {
                Credentials = new NetworkCredential(mailSettings.Username, mailSettings.Password),
                EnableSsl = true
            };
              client.Send(mailSettings.Username, mailContent.MailTo,mailContent.MailSubject, mailContent.MailBody);
            return true;
        }

        private MailContent FetchMailContent(FileInfo file)
        {
            MailContent mailContent = new MailContent();
            string path = @file.FullName;
            XDocument doc =  XDocument.Load(path);
            string mailTo = doc.Descendants("ToRecipients").FirstOrDefault().Value;
            string mailSubject = doc.Descendants("Subject").FirstOrDefault().Value;
            string mailBody= doc.Descendants("Body").FirstOrDefault().Value;
            mailContent.MailTo = mailTo;
            mailContent.MailSubject = mailSubject;
            mailContent.MailBody = mailBody;
            return mailContent;
        }
    }
}