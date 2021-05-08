using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class ReceipTurn : Receipt
    {
        public long TurnId { get; set; }

        public Turn Turn { get; set; }
    }
}
