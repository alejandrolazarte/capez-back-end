using System;

namespace CG.Domain.Entities
{
    public class PersonPhoneNumber : EntityBase , IAuditableEntity
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }
        
        public DateTime? DeletedDateAtUtc { get; set; }
        
        public DateTime? LastUpdateDateAtUtc { get; set; }
    }
}
