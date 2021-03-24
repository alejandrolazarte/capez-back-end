using System;

namespace CG.Domain.Entities
{
    public class Company : EntityBase, IAuditableEntity
    {
        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string TaxId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }

        public DateTime? DeletedDateAtUtc { get; set; }

        public DateTime? LastUpdateDateAtUtc { get; set; }
    }
}
