using Khuseinov_KT_42_20.DataBase.Helpers;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khuseinov_KT_42_20.DataBase.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";
        
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                  .HasKey(p => p.DepartmentId)
                  .HasName($"pk_{TableName}_department_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи для кафедры");


            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_DepartmentName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя Кафедры");

            builder.Property(p => p.DateFoundation)
             .IsRequired()
             .HasColumnName("c_department_DateFoundation")
             .HasColumnType(ColumnType.DateTime)
             .HasComment("Дата основания кафедры");

            builder.Property(p => p.TeacherCount)
             .IsRequired()
             .HasColumnName("c_department_TeacherCount")
             .HasComment("Кол-во преподователей в кафедре");
        }
    }
}
