using Khuseinov_KT_42_20.Filters.StudentFilters;
using Khuseinov_KT_42_20.Filters.TeacherFilter;
using Khuseinov_KT_42_20.Interfaces.StudentInterface;
using Khuseinov_KT_42_20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Threading;

namespace Khuseinov_KT_42_20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet]
        [Route("GetTeachersAsync")]
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            var teachers = await _teacherService.GetTeachersAsync();

            return teachers;
        }

        [HttpPost]
        [Route("GetTeachersByDepartmentAsync")]
        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);
            
            return teachers;
        }

        [HttpPost]
        [Route("GetTeachersByAcademicDegreeAsync")]
        public async Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByAcademicDegreeAsync(filter, cancellationToken);

            return teachers;
        }
    }
}
