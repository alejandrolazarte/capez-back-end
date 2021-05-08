using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class ReceipService : Receipt
    {
        public long ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
