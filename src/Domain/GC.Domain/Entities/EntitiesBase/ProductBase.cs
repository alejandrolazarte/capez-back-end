using System;

namespace CG.Domain.Entities.EntitiesBase
{
    public abstract class ProductBase : EntityBase, IAuditableEntity
    {
        public string Description { get; set; }

        public string Code { get; set; }

        public decimal Stock { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }

        public DateTime? DeletedDateAtUtc { get; set; }

        public DateTime? LastUpdateDateAtUtc { get; set; }
    }
}
