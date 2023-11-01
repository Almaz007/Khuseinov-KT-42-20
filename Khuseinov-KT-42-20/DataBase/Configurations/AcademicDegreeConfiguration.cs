using Khuseinov_KT_42_20.DataBase.Helpers;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khuseinov_KT_42_20.DataBase.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academicDegree";
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{TableName}_academicDegree_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("academicDegree_id")
                .HasComment("Идентификатор записи для ученой степени");


            builder.Property(p => p.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_AcademicDegreeName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название ученой степени");
        }
    }
}
