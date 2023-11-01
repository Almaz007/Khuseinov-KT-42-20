using Khuseinov_KT_42_20.Filters.DepartmentFilter;
using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Filters.TeacherFilter;
using Khuseinov_KT_42_20.Interfaces.DepartmentInterface;
using Khuseinov_KT_42_20.Interfaces.StudentInterface;
using Khuseinov_KT_42_20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khuseinov_KT_42_20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartmentsAsync")]
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _departmentService.GetDepartmentsAsync();

            return departments;
        }

        [HttpPost]
        [Route("GetDepartmentsByDateFoundationAsync")]
        public async Task<Department[]> GetDepartmentsByDateFoundationAsync(DepartmentDateFoundationFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = await _departmentService.GetDepartmentsByDateFoundationAsync(filter, cancellationToken);

            return departments;
        }

        [HttpPost]
        [Route("GetDepartmentsByTeacherCountAsync")]
        public async Task<Department[]> GetDepartmentsByTeacherCountAsync(DepartmentTeacherCountFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = await _departmentService.GetDepartmentsByTeacherCountAsync(filter, cancellationToken);

            return departments;
        }
    }
}
