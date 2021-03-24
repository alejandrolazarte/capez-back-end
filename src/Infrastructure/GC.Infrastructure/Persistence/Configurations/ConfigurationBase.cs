using CG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CG.Infrastructure.Persistence.Configurations
{
    public abstract class ConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureEntity(builder);
            builder.HasQueryFilter(x => !x.Deleted);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
