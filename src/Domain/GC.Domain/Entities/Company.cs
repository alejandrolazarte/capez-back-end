using CG.Domain.Entities.EntitiesBase;
using System;
using System.Collections.Generic;

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

        public ICollection<Product> Prodcuts { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<Turn> Turns { get; set; }
    }
}
