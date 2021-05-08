using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class ReceipProduct : Receipt
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public long ProductId  { get; set; }

        public Product Product { get; set; }
    }
}
