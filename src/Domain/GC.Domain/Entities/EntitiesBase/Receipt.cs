using System;

namespace CG.Domain.Entities.EntitiesBase
{
    public class Receipt : EntityBase, IAuditableEntity
    {
        public long CompanyId { get; set; }

        public Company Company { get; set; }

        public long ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }

        public DateTime? DeletedDateAtUtc { get; set; }

        public DateTime? LastUpdateDateAtUtc { get; set; }
    }
}
