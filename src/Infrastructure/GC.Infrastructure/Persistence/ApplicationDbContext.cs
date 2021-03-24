using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CG.Domain.Entities;
using CG.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CG.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<SystemAccount>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<PersonPhoneNumber> PersonPhoneNumbers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetAuditProperties();
            MarkLogicalDeleteEntity();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }

        private void SetAuditProperties()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateAtUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDateAtUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedDateAtUtc = DateTime.UtcNow;
                        break;
                }
            }
        }

        private void MarkLogicalDeleteEntity()
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains(nameof(EntityBase.Deleted)))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues[nameof(EntityBase.Deleted)] = true;
            }
        }
    }
}
