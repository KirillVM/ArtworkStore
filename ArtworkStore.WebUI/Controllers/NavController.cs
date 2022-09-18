using ArtworkStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtworkStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        public IArtworkRepository repository;
        public NavController(IArtworkRepository repository)
        {
            this.repository = repository;
        }
        // GET: Nav
        public PartialViewResult Menu(string technique = null)
        {
            ViewBag.SelectedTechnique = technique;

            IEnumerable<string> techniques = repository.Artworks
                .Select(artwork => artwork.Technique)
                .Distinct()
                .OrderBy(x =>x);
            return PartialView(techniques);
        }
    }
}