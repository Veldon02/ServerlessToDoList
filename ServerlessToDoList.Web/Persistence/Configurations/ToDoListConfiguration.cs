using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Persistence.Configurations;

public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
{
    public void Configure(EntityTypeBuilder<ToDoList> builder)
    {
        builder.ToTable("ToDoList");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar(50)");

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("getutcdate()");

        builder.HasMany(x => x.Items)
            .WithOne(x => x.ToDoList);
    }
}