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

        public ActionResult Details(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create([Bind(Include = "Title,Artist,Genre,Year,Price")] Album item)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult Edit(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult Edit([Bind(Include = "Id,Title,Artist,Genre,Year,Price")] Album item)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult Delete(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
