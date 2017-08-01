using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Hermes.Clients;
using RSS.EmailEngine.Models;

namespace SISImportMonitor.BLL
{
    public class SisEmailQueueBLL
    {
        public async Task<bool> AddToQueue(string toEmail, string emailTemplate,
            Dictionary<string, string> replacementValues)
        {
            var hermesApi = ConfigurationManager.AppSettings["HermesApi"];
            var applicationId = Convert.ToInt16(ConfigurationManager.AppSettings["ApplicationId"]);
            var authorizationToken = ConfigurationManager.AppSettings["EmailAuthorizationToken"];
            var sendEmails = Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmails"] ?? "false");

            var sendEmailClient = new SendEmailClient(hermesApi);

            if (sendEmails)
            {
                if (!String.IsNullOrEmpty(toEmail))
                {
                    var emailItem = new EmailItem
                    {
                        ToEmail = toEmail,
                        ApplicationId = applicationId,
                        EmailTemplate = emailTemplate,
                        AuthorizationToken = authorizationToken,
                        ReplacementValues = replacementValues,
                    };

                    await sendEmailClient.PublishTemplateAsync(emailItem);
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}