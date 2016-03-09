using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LucyManager.MVC.Models;

namespace LucyManager.MVC.Controllers
{
    public class LocaisController : Controller
    {
        private LucyManagerDbContext db = new LucyManagerDbContext();

        // GET: Locais
        public ActionResult Index()
        {
            return View(db.Local.ToList());
        }

        // GET: Locais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locais locais = db.Local.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        // GET: Locais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locais/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalId,Nome,NomeAbreviado,Descricao")] Locais locais)
        {
            if (ModelState.IsValid)
            {
                db.Local.Add(locais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locais);
        }

        // GET: Locais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locais locais = db.Local.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        // POST: Locais/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalId,Nome,NomeAbreviado,Descricao")] Locais locais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locais);
        }

        // GET: Locais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locais locais = db.Local.Find(id);
            if (locais == null)
            {
                return HttpNotFound();
            }
            return View(locais);
        }

        // POST: Locais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locais locais = db.Local.Find(id);
            db.Local.Remove(locais);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}