using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Data.Mappings
{
    public class ToDoMap : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.LastUpdateDate);
            builder.Property(x => x.Done).IsRequired();
        }
    }
}
