using System.Threading.Tasks;
using SISImportMonitor.BLL;

namespace SISImportMonitor.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckStatusSisImport().Wait();
        }

        private static async Task CheckStatusSisImport()
        {
            var importStatusBll = new ImportStatusBLL();
            await importStatusBll.GetBatchImportStatus();
        }
    }  
}
