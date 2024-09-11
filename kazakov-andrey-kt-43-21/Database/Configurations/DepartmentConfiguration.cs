
using kazakov_andrey_kt_43_21.Database.Helper;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kazakov_andrey_kt_43_21.Database.Configurations
{
  public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
  {
    private const string TableName = "cd_departament";

    public void Configure(EntityTypeBuilder<Department> builder)
    {
      builder.HasKey(p => p.DepartmentId)
             .HasName($"pk_{TableName}_department_id");

      builder.Property(p => p.DepartmentId)
              .ValueGeneratedOnAdd();

      //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
      builder.Property(p => p.DepartmentId)
          .HasColumnName("department_id")
          .HasComment("Идентификатор записи кафедры");

      //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
      builder.Property(p => p.DepartmentName)
          .IsRequired()
          .HasColumnName("c_department_name")
          .HasColumnType(ColumnType.String).HasMaxLength(150)
          .HasComment("Название кафедры");

      builder.ToTable(TableName);
    }
  }
}
