using ArtworkStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Abstract
{
    public interface ICartRepository
    {
        IEnumerable<Cart> Carts { get; set; }
    }
}
