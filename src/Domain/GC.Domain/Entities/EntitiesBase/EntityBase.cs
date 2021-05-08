using System.ComponentModel.DataAnnotations;

namespace CG.Domain.Entities.EntitiesBase
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }

        public bool Deleted { get; set; }
    }
}
