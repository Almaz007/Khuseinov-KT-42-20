
using Khuseinov_KT_42_20.DataBase.Helpers;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khuseinov_KT_42_20.DataBase.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //задаем первичный ключ
            builder
                 .HasKey(p => p.StudentId)
                 .HasName($"pk_{TableName}_student_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_FirstName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");


            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_LastName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
               .IsRequired()
               .HasColumnName("c_student_MiddleName")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
               .HasColumnName("c_student_GroupId")
               .HasComment("Внешний ключ на группу");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId);
            builder.Navigation(p => p.Group);
        }
    }
}
