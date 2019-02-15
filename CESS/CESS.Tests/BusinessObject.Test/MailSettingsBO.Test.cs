using System;
using System.Collections.Generic;
using System.Text;
using CESS.BusineessObject;
using CESS.Models;
using NUnit.Framework;

namespace CESS.Tests.BusinessObject.Tests
{
    [TestFixture]
    class MailSettingsBOTest
    {

        private readonly MailSettingsBO mailSettingsBO;

        public MailSettingsBOTest()
        {
            mailSettingsBO = new MailSettingsBO();
        }

        [Test]
        [TestCase("mail.1254")]
        public void IsInvalidServerAddress(string serverAddress)
        {
            var result = mailSettingsBO.IsServerAddress(serverAddress);
            Assert.IsFalse(result, $"{serverAddress} is not valid serveraddress");
        }


        [Test]
        [TestCase("mail.gmail.com")]
        public void IsValidServerAddress(string serverAddress)
        {
            var result = mailSettingsBO.IsServerAddress(serverAddress);
            Assert.IsTrue(result, $"{serverAddress} is valid serveraddress");
        }

        [Test]
        public void SaveSettingsToFile()
        {
           
        }
    }
}
