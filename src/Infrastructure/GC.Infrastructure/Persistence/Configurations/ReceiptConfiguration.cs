using CG.Domain.Entities.EntitiesBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CG.Infrastructure.Persistence.Configurations
{
    public class ReceiptConfiguration : EntityConfigurationBase<Receipt>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receips");
        }
    }
}
