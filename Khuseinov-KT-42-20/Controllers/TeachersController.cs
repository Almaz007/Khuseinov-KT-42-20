using Khuseinov_KT_42_20.Data;
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
        private readonly AppDbContext _dbContext;
        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService, AppDbContext dbContext)
        {
            _logger = logger;
            _teacherService = teacherService;
            _dbContext = dbContext;
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
        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter);
            
            return teachers;
        }

        [HttpPost]
        [Route("GetTeachersByAcademicDegreeAsync")]
        public async Task<Teacher[]> GetTeachersByAcademicDegreeAsync(TeacherAcademicDegreeFilter filter)
        {
            var teachers = await _teacherService.GetTeachersByAcademicDegreeAsync(filter);

            return teachers;
        }

        [HttpPost]
        [Route("createTeacher")]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            
            await _teacherService.CreateTeacher(teacher);

            return Ok("create was successful");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }
            
            try
            {
               await _teacherService.UpdateTeacher(teacher);

                return Ok("vse ok");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

        }

        // DELETE:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
           
            var teacher = await _dbContext.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }
            await _teacherService.DeleteTeacher(teacher);

            return Ok("removal was successful");
        }
    }
}
