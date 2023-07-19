using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApp.Domain.Entities.Data.Mappings;

public class TodoItemMap : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasColumnName("Title").HasColumnType("VARCHAR").HasMaxLength(160);
        builder.Property(x => x.User).IsRequired().HasColumnName("User").HasColumnType("VARCHAR").HasMaxLength(120);
        builder.Property(x => x.Done).HasColumnType("BIT");
        builder.Property(x => x.Date).IsRequired().HasColumnName("Date").HasColumnType("SMALLDATETIME");

        builder.HasIndex(x => x.User);
    }
}
