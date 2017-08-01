using System.Collections.Generic;
using Newtonsoft.Json;

namespace SISImportMonitor.Models
{
    public class Data
    {
        [JsonProperty(PropertyName = "import_type")]
        public string ImportType { get; set; }

        [JsonProperty(PropertyName = "counts")]
        public Counts Counts { get; set; }

        [JsonProperty(PropertyName = "supplied_batches")]
        public List<string> SuppliedBatches { get; set; }
    }
}