using System.Collections.Generic;
using Newtonsoft.Json;

namespace SISImportMonitor.Models
{
    public class SisImport
    {
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "started_at")]
        public string StartedAt { get; set; }

        [JsonProperty(PropertyName = "ended_at")]
        public string EndedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public int Progress { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "workflow_state")]
        public string WorkflowState { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }

        [JsonProperty(PropertyName = "batch_mode")]
        public object BatchMode { get; set; }

        [JsonProperty(PropertyName = "batch_mode_term_id")]
        public object BatchModeTermId { get; set; }

        [JsonProperty(PropertyName = "override_sis_stickiness")]
        public object OverrideSisStickiness { get; set; }

        [JsonProperty(PropertyName = "add_sis_stickiness")]
        public object AddSisStickiness { get; set; }

        [JsonProperty(PropertyName = "clear_sis_stickiness")]
        public object ClearSisStickiness { get; set; }

        [JsonProperty(PropertyName = "diffing_data_set_identifier")]
        public object DiffingDataSetIdentifier { get; set; }

        [JsonProperty(PropertyName = "diffed_against_import_id")]
        public object DiffedAgainstImportId { get; set; }

        [JsonProperty(PropertyName = "processing_errors")]
        public List<List<string>> ProcessingErrors { get; set; }
    }
}