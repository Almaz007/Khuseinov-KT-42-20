using Khuseinov_KT_42_20.DataBase.Configurations;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace Khuseinov_KT_42_20.Data
{
    public class StudentDbContext:DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
        {
        
        }
    }
}
