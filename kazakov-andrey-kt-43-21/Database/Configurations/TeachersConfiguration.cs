using kazakov_andrey_kt_43_21.Database.Helper;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_andrey_kt_43_21.Database.Configurations
{
  public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
  {
    private const string TableName = "cd_teacher";
    public void Configure(EntityTypeBuilder<Teachers> builder)
    {
      builder
        .HasKey(t => t.TeachersId)
        .HasName($"pk_{TableName}_teacher_id");

      builder.Property(t => t.TeachersId)
        .HasColumnName("teacher_id")
        .HasComment("Идентификатор записи студента");

      builder.Property(p => p.FirstName)
        .IsRequired()
        .HasColumnName("c_teacher_firstname")
        .HasColumnType(ColumnType.String).HasMaxLength(100);

      builder.Property(p => p.LastName)
        .IsRequired()
        .HasColumnName("c_teacher_lastname")
        .HasColumnType(ColumnType.String).HasMaxLength(100);

      builder.Property(p => p.MiddleName)
          .HasColumnName("c_teacher_middlename")
          .HasColumnType(ColumnType.String).HasMaxLength(100);

      builder.Property(p => p.DepartmentId)
        .IsRequired()
        .HasColumnName("c_department_id")
        .HasColumnType(ColumnType.String);

      builder.ToTable(TableName)
        .HasOne(p => p.Department)
        .WithMany()
        .HasForeignKey(p => p.DepartmentId)
        .HasConstraintName("fk_c_department_id")
        .OnDelete(DeleteBehavior.Cascade);

      builder.ToTable(TableName)
        .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_c_department_id");

      builder.Navigation(p => p.Department)
        .AutoInclude();

    //https://github.com/Evil-maker/ivan-ivanov-kt-31-20/blob/master/IvanIvanovKt-31-20/Database/Configurations/StudentConfiguration.cs

      //builder.Property(p => p.PositionId)
      //  .IsRequired()
      //  .HasColumnName("c_position_id")
      //  .HasColumnType(ColumnType.String);

      //builder.ToTable(TableName)
      //  .HasOne(p => p.Position)
      //  .WithMany()
      //  .HasForeignKey(p => p.PositionId)
      //  .HasConstraintName("fk_c_position_id")
      //  .OnDelete(DeleteBehavior.Cascade);

      //builder.ToTable(TableName)
      //  .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_c_department_id");

      //builder.Navigation(p => p.Department)
      //  .AutoInclude();
    }
  }
}
