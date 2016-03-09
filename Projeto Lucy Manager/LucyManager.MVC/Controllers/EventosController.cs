using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LucyManager.MVC.Models;

namespace LucyManager.MVC.Controllers
{
    public class EventosController : Controller
    {
        private LucyManagerDbContext db = new LucyManagerDbContext();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(db.Evento.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Evento.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventoId,Descricao")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Evento.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Evento.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventoId,Descricao")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Evento.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.Evento.Find(id);
            db.Evento.Remove(eventos);
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