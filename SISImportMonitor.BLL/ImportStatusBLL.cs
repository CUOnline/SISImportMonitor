using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SISImportMonitor.Models;

namespace SISImportMonitor.BLL
{
    public class ImportStatusBLL
    {
        public async Task GetBatchImportStatus()
        {
            var baseURI = "https://ucdenver.instructure.com";
            var requestPath = "/api/v1/accounts/self/sis_imports";
            var token = ConfigurationManager.AppSettings["token"];  //"1043~xA7MhFfVQsedO9NVERFj1Mu4sBfAVq8T7fglgEpWpgHZ6A5fs82XqjtRiWP2NBQV";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var importEmail = new SisImportEmailBLL();
                var response = await client.GetAsync(requestPath);
                string responseString;

                if (response.IsSuccessStatusCode)
                    responseString = await response.Content.ReadAsStringAsync();
                else
                    throw new Exception(response.StatusCode + response.ReasonPhrase);

                var sisImports = JsonConvert.DeserializeObject<SISImports>(responseString);
                await importEmail.SendImportStatusEmail(sisImports);
            }
        }
    }
}