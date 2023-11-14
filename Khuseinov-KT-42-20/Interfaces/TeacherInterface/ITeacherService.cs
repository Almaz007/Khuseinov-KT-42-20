using Khuseinov_KT_42_20.Data;
using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Filters.TeacherFilter;
using Khuseinov_KT_42_20.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Khuseinov_KT_42_20.Interfaces.StudentInterface
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> GetTeachersAsync();
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter);
        public Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter);
        public Task CreateTeacher(Teacher teacher);
        public Task DeleteTeacher(Teacher teacher);
        public Task UpdateTeacher(Teacher teacher);
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
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter)
        {
            var teachers = _dbContext.Set<Teacher>().Where(e => e.Department.DepartmentName == filter.DepartmentName).ToArrayAsync();

            return teachers;
        }
        public Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter)
        {
            var teachers = _dbContext.Set<Teacher>().Where(e => e.AcademicDegree.AcademicDegreeName == filter.AcademicDegreeName).ToArrayAsync();

            return teachers;
        }
        public async Task CreateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _dbContext.Entry(teacher).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
    
}
