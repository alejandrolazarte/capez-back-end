using System;
using System.Collections.Generic;
using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class Turn : EntityBase, IAuditableEntity
    {
        public DateTime Hour { get; set; }

        public DateTime CreatedDateAtUtc { get; set; }
        
        public DateTime? DeletedDateAtUtc { get; set; }
        
        public DateTime? LastUpdateDateAtUtc { get; set; }

        public ICollection<ReceipTurn> ReceipTurns { get; set; }
    }
}
