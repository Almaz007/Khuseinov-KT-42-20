using Khuseinov_KT_42_20.DataBase.Helpers;
using Khuseinov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khuseinov_KT_42_20.DataBase.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";
        
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                  .HasKey(p => p.GroupId)
                  .HasName($"pk_{TableName}_group_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи для группы");


            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_student_GroupName")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя группы");
        }
    }
}
