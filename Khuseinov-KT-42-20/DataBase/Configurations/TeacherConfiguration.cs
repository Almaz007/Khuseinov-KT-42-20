
using Khuseinov_KT_42_20.DataBase.Helpers;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khuseinov_KT_42_20.DataBase.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //задаем первичный ключ
            builder
                 .HasKey(p => p.TeacherId)
                 .HasName($"pk_{TableName}_teacher_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподователя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_FirstName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподователя");


            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_LastName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподователя");

            builder.Property(p => p.MiddleName)
               .IsRequired()
               .HasColumnName("c_teacher_MiddleName")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Отчество преподователя");

            builder.Property(p => p.DepartmentId)
               .HasColumnName("c_teacher_DepartmentId")
               .HasComment("Внешний ключ на Кафедру");

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithMany(t => t.Teachers)
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepartmentId);
            builder.Navigation(p => p.Department);


            builder.Property(p => p.AcademicDegreeId)
               .HasColumnName("c_teacher_AcademicDegreeId")
               .HasComment("Внешний ключ на ученую ступень");

            builder.ToTable(TableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany(t => t.Teachers)
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_academicDegree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId);
            builder.Navigation(p => p.AcademicDegree);
        }
    }
}
