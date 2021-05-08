using System.Collections.Generic;
using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Entities
{
    public class Product : ProductBase
    {
        public ICollection<ReceipProduct> ReceipProducts { get; set; }
    }
}
