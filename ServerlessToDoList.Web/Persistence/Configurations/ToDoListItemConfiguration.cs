using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Persistence.Configurations;

public class ToDoListItemConfiguration : IEntityTypeConfiguration<ToDoListItem>
{
    public void Configure(EntityTypeBuilder<ToDoListItem> builder)
    {
        builder.ToTable("ToDoListItem");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasColumnType("tinyint");

        builder.Property(x => x.Item)
            .HasColumnType("nvarchar(150)");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("getutcdate()");
    }
}