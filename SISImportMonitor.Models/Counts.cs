using Newtonsoft.Json;

namespace SISImportMonitor.Models
{
    public class Counts
    {
        [JsonProperty(PropertyName = "accounts")]
        public int Accounts { get; set; }

        [JsonProperty(PropertyName = "terms")]
        public int Terms { get; set; }

        [JsonProperty(PropertyName = "abstract_courses")]
        public int AbstractCourses { get; set; }

        [JsonProperty(PropertyName = "courses")]
        public int Courses { get; set; }

        [JsonProperty(PropertyName = "sections")]
        public int Sections { get; set; }

        [JsonProperty(PropertyName = "xlists")]
        public int Xlists { get; set; }

        [JsonProperty(PropertyName = "users")]
        public int Users { get; set; }

        [JsonProperty(PropertyName = "user_observers")]
        public int UserObservers { get; set; }

        [JsonProperty(PropertyName = "enrollments")]
        public int Enrollments { get; set; }

        [JsonProperty(PropertyName = "groups")]
        public int Groups { get; set; }

        [JsonProperty(PropertyName = "group_memberships")]
        public int GroupMemberships { get; set; }

        [JsonProperty(PropertyName = "grade_publishing_results")]
        public int GradePublishingResults { get; set; }
    }
}