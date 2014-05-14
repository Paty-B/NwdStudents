using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nwd.BackOffice.Impl;
using Nwd.BackOffice.Model;
using Moq;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            ViewBag.Message = "Your admin index page";

            return View(new AlbumRepository().GetAllAlbums());
        }

        public ActionResult NewAlbum()
        {
            ViewBag.Message = "NewAlbum";
            AlbumModel am = new AlbumModel();
            return View("NewAlbum", am);
        }

        [HttpPost]
        public ActionResult NewAlbum( AlbumModel am)
        {
            AlbumRepository repo = new AlbumRepository();
            HttpServerUtilityBase server = Mock.Of<HttpServerUtilityBase>();

            Album album = repo.CreateAlbum(new Album
            {
                Duration = TimeSpan.FromHours(2),
                Title = am.Title,
                Artist = new Artist { Name = am.Artist },
                ReleaseDate = am.ReleaseDate,
                Type = "Pop-Rock"
            }, server);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Album(int id)
        {
            ViewBag.Message = "Album";
            return View(new AlbumRepository().GetAlbumForEdit(id));
        }

        [HttpGet]
        public ActionResult EditAlbum(int id)
        {
            ViewBag.Message = "Edition d'album";
            return View(new AlbumRepository().GetAlbumForEdit(id));
        }

        [HttpPost]
        public ActionResult EditAlbum(Album album)
        {
            HttpServerUtilityBase server = Mock.Of<HttpServerUtilityBase>();
            AlbumRepository repo = new AlbumRepository();
            repo.EditAlbum(server, album);
            return View("Album", album);
        }

        public ActionResult TrackTemplate()
        {
            return PartialView("TrackTemplate", );
        }
    }
}
