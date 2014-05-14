using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nwd.BackOffice.Impl;
using Nwd.BackOffice.Model;

namespace MvcApplication1.Controllers
{
    public class CatalogController : Controller
    {
        //
        // GET: /Catalog/

        public ActionResult Albums()
        {
            ViewBag.Message = "Catalog";
            return View(new AlbumRepository().GetAllAlbums());
        }

        public ActionResult Album(int id)
        {
            ViewBag.Message = "Album";
            return View(new AlbumRepository().GetAlbumForEdit(id));
        }

    }
}
