using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LucyManager.MVC.Models;
using System.Threading.Tasks;

namespace LucyManager.MVC.Controllers
{
    public class ReservasController : Controller
    {
        private LucyManagerDbContext db = new LucyManagerDbContext();

        // GET: Reservas
        public async Task<ActionResult> Index()
        {
            return View(await db.Reserva
                .Include(r => r.Local)
                .Include(r => r.Evento)
                .Include(r => r.Usuario)
                .OrderBy(r => r.DataInicialReserva).ToListAsync());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reserva.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public async Task<ActionResult> Create()
        {
            return await BuildView(null);
        }

        // POST: Reservas/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReservaId,DataInicialReserva,DataFinalReserva,LocalId,UserId,EventoId")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reservas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return await BuildView(reservas);
        }

        // GET: Reservas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var reserva = await db.Reserva.FindAsync(id);

            if (reserva == null)
            {
                return HttpNotFound();
            }

            return await BuildView(reserva);
        }

        // POST: Reservas/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReservaId,DataInicialReserva,DataFinalReserva,LocalId,UserId,EventoId")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;

                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return await BuildView(reservas);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reserva.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservas reservas = db.Reserva.Find(id);
            db.Reserva.Remove(reservas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> BuildView(Reservas reservas)
        {
            ViewBag.UsuarioId = new SelectList(
                await db.Users.ToListAsync(),
                "Id",
                "UserName",
                reservas == null ? null : (object)reservas.UserId);

            ViewBag.LocalId = new SelectList(
                await db.Local.ToListAsync(),
                "LocalId",
                "NomeAbreviado",
                reservas == null ? null : (object)reservas.LocalId);

            ViewBag.EventoId = new SelectList(
                await db.Evento.ToListAsync(),
                "EventoId",
                "Descricao",
                reservas == null ? null : (object)reservas.EventoId);

            return View(reservas);
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