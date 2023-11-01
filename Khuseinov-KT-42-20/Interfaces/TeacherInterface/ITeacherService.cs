using Khuseinov_KT_42_20.Data;
using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Filters.TeacherFilter;
using Khuseinov_KT_42_20.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Khuseinov_KT_42_20.Interfaces.StudentInterface
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> GetTeachersAsync();
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _dbContext;

        public TeacherService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Teacher>> GetTeachersAsync()
        {
            var teachers = _dbContext.Teachers.ToListAsync();

            return teachers;
        }
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(e => e.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);
          
            return teachers;
        }
        public Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(e => e.AcademicDegree.AcademicDegreeName == filter.AcademicDegreeName).ToArrayAsync(cancellationToken);

            return teachers;
        }
    }
}
