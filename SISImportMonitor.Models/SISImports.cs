using System.Collections.Generic;
using Newtonsoft.Json;

namespace SISImportMonitor.Models
{
    public class SISImports
    {
        [JsonProperty(PropertyName = "sis_imports")]
        public List<SisImport> SisImports { get; set; }
    }
}