using Khuseinov_KT_42_20.Data;
using Khuseinov_KT_42_20.Filters.DepartmentFilter;
using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Filters.TeacherFilter;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace Khuseinov_KT_42_20.Interfaces.DepartmentInterface
{

    public interface IDepartmentService
    {
        public Task<List<Department>> GetDepartmentsAsync();
        public Task<Department[]> GetDepartmentsByDateFoundationAsync(DepartmentDateFoundationFilter filter, CancellationToken cancellationToken);
        public Task<Department[]> GetDepartmentsByTeacherCountAsync(DepartmentTeacherCountFilter filter, CancellationToken cancellationToken);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _dbContext;

        public DepartmentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = _dbContext.Departments.ToListAsync();

            return departments;
        }
        public Task<Department[]> GetDepartmentsByDateFoundationAsync(DepartmentDateFoundationFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = _dbContext.Set<Department>().Where(e => e.DateFoundation == filter.DateFoundation).ToArrayAsync(cancellationToken);

            return departments;
        }
        public Task<Department[]> GetDepartmentsByTeacherCountAsync(DepartmentTeacherCountFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = _dbContext.Set<Department>().Where(e => e.TeacherCount >= filter.TeacherCount).ToArrayAsync(cancellationToken);

            return departments;
        }
    }
}
