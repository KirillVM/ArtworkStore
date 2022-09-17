using ArtworkStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtworkStore.WebUI.Models
{
    public class ArtworkListViewModel
    {
        public IEnumerable<Artwork> Artworks { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}