using System;
using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class Client : EntityBase, IAuditableEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email  { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }

        public DateTime? DeletedDateAtUtc { get; set; }

        public DateTime? LastUpdateDateAtUtc { get; set; }
    }
}
