using CG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CG.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : EntityConfigurationBase<Company>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.TaxId).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
        }
    }
}
