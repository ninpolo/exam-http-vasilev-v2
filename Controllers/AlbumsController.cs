using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamMvc.Models;

namespace ExamMvc.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ExamContext db = new ExamContext();

        [HttpGet]
        public ActionResult Index(string search, string category)
        {
            ViewBag.Categories = db.Albums.Select(x => x.Genre).Distinct().OrderBy(c => c).ToList();
            ViewBag.Search = search;
            ViewBag.Category = category;

            IQueryable<Album> albums = db.Albums;
            if (!string.IsNullOrWhiteSpace(search))
                albums = albums.Where(x => x.Title.Contains(search) || x.Artist.Contains(search));
            if (!string.IsNullOrWhiteSpace(category))
                albums = albums.Where(x => x.Genre == category);

            return View(albums.OrderBy(x => x.Title).ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Album item = db.Albums.Find(id.Value);
            if (item == null)
                return HttpNotFound();
            return View(item);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Artist,Genre,Year,Price")] Album item)
        {
            if (!ModelState.IsValid)
                return View(item);

            db.Albums.Add(item);
            db.SaveChanges();
            TempData["Message"] = "Album added successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Album item = db.Albums.Find(id.Value);
            if (item == null)
                return HttpNotFound();
            return View(item);
        }

        [HttpPut]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPut([Bind(Include = "Id,Title,Artist,Genre,Year,Price")] Album item)
        {
            Album existing = db.Albums.Find(item.Id);
            if (existing == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
                return View("Edit", item);

            existing.Title = item.Title;
            existing.Artist = item.Artist;
            existing.Genre = item.Genre;
            existing.Year = item.Year;
            existing.Price = item.Price;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return HttpNotFound();
            }

            TempData["Message"] = "Album updated successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Album item = db.Albums.Find(id.Value);
            if (item == null)
                return HttpNotFound();
            return View(item);
        }

        [HttpDelete]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album item = db.Albums.Find(id);
            if (item == null)
                return HttpNotFound();

            db.Albums.Remove(item);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return HttpNotFound();
            }

            TempData["Message"] = "Album deleted successfully.";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
