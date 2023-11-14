using System.Text.Json.Serialization;

namespace Khuseinov_KT_42_20.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string? AcademicDegreeName { get; set; }
        [JsonIgnore]
        public List<Teacher>? Teachers { get; set; }
    }
}
