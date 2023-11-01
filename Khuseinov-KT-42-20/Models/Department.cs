namespace Khuseinov_KT_42_20.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime DateFoundation { get; set; }

        public int TeacherCount { get; set; }

        public List<Teacher>? Teachers { get; set; }
    }
}
