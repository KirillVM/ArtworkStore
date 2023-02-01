using ArtworkStore.Domain.Abstract;
using ArtworkStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Concrete
{
    class EFCartRepository : ICartRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Cart> Carts
        {
            get => context.Carts;
            set
            {
                context.Carts.Add((Cart)value);
            }
        }
    }
}
