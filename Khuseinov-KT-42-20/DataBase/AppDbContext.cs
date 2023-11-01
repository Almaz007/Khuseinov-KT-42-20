using Khuseinov_KT_42_20.DataBase.Configurations;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace Khuseinov_KT_42_20.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public  DbSet<AcademicDegree> AcademicDegrees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
    }
}
