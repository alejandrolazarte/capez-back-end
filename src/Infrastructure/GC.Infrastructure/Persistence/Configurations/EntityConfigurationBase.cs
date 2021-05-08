using CG.Domain.Entities.EntitiesBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CG.Infrastructure.Persistence.Configurations
{
    public abstract class EntityConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureEntity(builder);
            builder.HasQueryFilter(x => !x.Deleted);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
