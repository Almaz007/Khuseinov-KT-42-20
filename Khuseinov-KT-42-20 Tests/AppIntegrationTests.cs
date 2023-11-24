using Khuseinov_KT_42_20.Data;
using Khuseinov_KT_42_20.Interfaces.StudentInterface;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Khuseinov_KT_42_20_Tests
{
    public class AppIntegrationTests
    {
        public readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public AppIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "dbbb").Options;
               ;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4220_threeObjects()
        {
            // Arrange
            var ctx = new AppDbContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            var academicDegrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    AcademicDegreeName = "Кандидат наук"
                },
                new AcademicDegree
                {
                    AcademicDegreeName = "Доктор наук"
                }
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicDegrees);

            var Departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "ИВТ",
                    DateFoundation = new DateTime(2008, 12, 09),
                    TeacherCount = 7
                },
                new Department
                {
                    DepartmentName = "КТ",
                    DateFoundation = new DateTime(2006, 11, 02),
                    TeacherCount = 10
                },
                 new Department
                {
                    DepartmentName = "РЭА",
                    DateFoundation = new DateTime(2002, 09, 09),
                    TeacherCount = 15
                },
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicDegrees);

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    DepartmentId = 1,
                    AcademicDegreeId = 1
                },
                new Teacher
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    DepartmentId = 2,
                    AcademicDegreeId = 1
                },
                new Teacher
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    DepartmentId = 1,
                    AcademicDegreeId = 2
                },
                new Teacher
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    DepartmentId = 1,
                    AcademicDegreeId = 1
                }
            };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Khuseinov_KT_42_20.Filters.TeacherFilter.TeacherAcademicDegreeFilter
            {
                AcademicDegreeName = "Кандидат наук"
            };
            var teachersResult = await teacherService.GetTeachersByAcademicDegreeAsync(filter);

            // Assert
            Assert.Equal(3, teachersResult.Length);
        }

    }
}