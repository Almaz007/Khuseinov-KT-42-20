
using System.Text.Json.Serialization;

namespace Khuseinov_KT_42_20.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set;}
        
        public string? LastName { get; set; }
        
        public string? MiddleName { get; set;}
        
        public int DepartmentId { get; set;}
        public int AcademicDegreeId { get; set;}

        [JsonIgnore]
        public Department? Department { get; set;}
        
        [JsonIgnore]
        public AcademicDegree? AcademicDegree { get; set;}

        public bool IsvalidTeacherFirstName()
        {
            if (FirstName.Length == 0 || FirstName.Length <= 3)
            {
                return false;
            }

            return true;
        }
    }
}
