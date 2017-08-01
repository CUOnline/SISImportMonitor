using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using SISImportMonitor.Models;

namespace SISImportMonitor.BLL
{
    public class SisImportEmailBLL
    {
        public async Task SendImportStatusEmail(SISImports imports)
        {
            var replacements = SetReplacements(imports);
            var toEmail = ConfigurationManager.AppSettings["OrderEmail"];
            await SendEmail(toEmail, replacements, "CUOnline_SISImportStatus");
        }

        private Dictionary<string, string> SetReplacements(SISImports imports)
        {
            var failedCount = 0;
            var failedDates = new StringBuilder();
            var successCount = 0;
            var successDates = new StringBuilder("<ul>");
            var currentCount = 0;
            var currentDates = new StringBuilder();
            var totalCount = 0;
            var dateFormat = "yyyy-MM-dd HH':'mm':'ss";

            foreach (var sisBatch in imports.SisImports)
            {
                if (sisBatch.WorkflowState.Trim() == "imported")
                {
                    successCount += 1;
                    successDates.Append(GetDateText(sisBatch));
                }
                else if (sisBatch.WorkflowState.Trim() == "importing")
                {
                    currentCount += 1;
                    currentDates.Append(GetDateText(sisBatch));
                }
                else
                {
                    failedCount += 1;
                    failedDates.Append(GetDateText(sisBatch));
                }

                totalCount += 1;
            }

            successDates.Append("</ul>");

            return new Dictionary<string, string>
                {
                    {"@FAILED", failedCount.ToString()},
                    {"@SISERROR",failedDates.ToString()},
                    {"@CURRENT", currentCount.ToString()},
                    {"@STARTTIME", currentDates.ToString()},
                    {"@SUCCESS", successCount.ToString()},
                    {"@IMPORTDATES", successDates.ToString()},
                    {"@COUNT", totalCount.ToString()},
                };

            string GetDateText(SisImport sisImport)
            {
                return $"<li>{Convert.ToDateTime(sisImport.CreatedAt).ToString(dateFormat)}</li>";
            }
        }

        private async Task SendEmail(string toEmail, Dictionary<string, string> replacements, string emailTemplateName)
        {
            var emailQueueBll = new SisEmailQueueBLL();
            await emailQueueBll.AddToQueue(toEmail, emailTemplateName, replacements);
        }
    }
}