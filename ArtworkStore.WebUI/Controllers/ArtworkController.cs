using ArtworkStore.Domain.Abstract;
using ArtworkStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtworkStore.WebUI.Controllers
{
    public class ArtworkController : Controller
    {
        private IArtworkRepository repository;
        public int pageSize = 6;
        public ArtworkController(IArtworkRepository repository)
        {
            this.repository = repository;
        }
        // GET: Artwork
        public ViewResult List(int page=1)
        {
            ArtworkListViewModel model = new ArtworkListViewModel
            {
                Artworks = repository.Artworks
                    .OrderBy(artwork => artwork.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo  = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Artworks.Count()
                }
            };
            return View(model);
        }   
    }
}