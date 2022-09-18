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
        public int pageSize = 3;
        public ArtworkController(IArtworkRepository repository)
        {
            this.repository = repository;
        }
        // GET: Artwork
        public ViewResult List(string technique,int page=1)
        {
            ArtworkListViewModel model = new ArtworkListViewModel
            {
                Artworks = repository.Artworks
                    .Where(p => technique == null || p.Technique == technique)
                    .OrderBy(artwork => artwork.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = technique == null ?
                repository.Artworks.Count() :
                repository.Artworks.Where(artworks => artworks.Technique == technique).Count()
},
                CurrentTechnique = technique
            };
            return View(model);
        }   
    }
}