using Khuseinov_KT_42_20.Data;
using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Khuseinov_KT_42_20.Interfaces.StudentInterface
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(e => e.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
          
            return students;
        }
    }
}
