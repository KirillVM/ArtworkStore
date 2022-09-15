using ArtworkStore.Domain.Abstract;
using ArtworkStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Concrete
{
    public class EFArtworkRepository : IArtworkRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable <Artwork> Artworks
        {
            get { return context.Artworks; }
        }
    }
}
