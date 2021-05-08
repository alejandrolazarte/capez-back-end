using CG.Domain.Entities.EntitiesBase;
using System.Collections.Generic;

namespace CG.Domain.Entities
{
    public class Service : ProductBase
    {
        public ICollection<ReceipService> ReceipServices { get; set; }
    }
}
