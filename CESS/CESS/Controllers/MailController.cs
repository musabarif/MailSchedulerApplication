using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWithScheduler.Code;
using CESS.BusineessObject;
using CESS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private MailSettingsBO mailsettingsBO=new MailSettingsBO();
        [HttpPost("[action]")]
        public Boolean SaveSettings(MailSettings model)
        {
            try
            {
                return mailsettingsBO.SaveSettings(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                //Need to add logging
            }
            
        }

        [HttpPost("[action]")]
        public Boolean ValidateSettings(MailSettings model)
        {
            try
            {
              
                return mailsettingsBO.ValidateSettings(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return  false;
                //Need to add logging
            }

        }

    }
}