using EntityFrameworkVsCoreDapper.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class ValueChoiceMap : IEntityTypeConfiguration<ValueChoice>
    {
        public void Configure(EntityTypeBuilder<ValueChoice> builder)
        {
            builder.Property(_ => _.Code).IsRequired().HasMaxLength(25);
            builder.Property(_ => _.Description).IsRequired().HasMaxLength(150);
        }
    }
}
