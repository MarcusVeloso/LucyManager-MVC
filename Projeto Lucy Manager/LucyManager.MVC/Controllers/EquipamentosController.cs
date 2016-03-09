using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LucyManager.MVC.Models;

namespace LucyManager.MVC.Controllers
{
    public class EquipamentosController : Controller
    {
        private LucyManagerDbContext db = new LucyManagerDbContext();

        // GET: Equipamentos
        public ActionResult Index()
        {
            return View(db.Equipamento.ToList());
        }

        // GET: Equipamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamentos equipamentos = db.Equipamento.Find(id);
            if (equipamentos == null)
            {
                return HttpNotFound();
            }
            return View(equipamentos);
        }

        // GET: Equipamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamentos/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipamentoId,Patrimonio,Nome,Descricao,DataAquisicao,DataManutencao,DataProximaManutencao,LocalOrigemId,LocalDestinoId,Ativo")] Equipamentos equipamentos)
        {
            if (ModelState.IsValid)
            {
                db.Equipamento.Add(equipamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipamentos);
        }

        // GET: Equipamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamentos equipamentos = db.Equipamento.Find(id);
            if (equipamentos == null)
            {
                return HttpNotFound();
            }
            return View(equipamentos);
        }

        // POST: Equipamentos/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipamentoId,Patrimonio,Nome,Descricao,DataAquisicao,DataManutencao,DataProximaManutencao,LocalOrigemId,LocalDestinoId,Ativo")] Equipamentos equipamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipamentos);
        }

        // GET: Equipamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamentos equipamentos = db.Equipamento.Find(id);
            if (equipamentos == null)
            {
                return HttpNotFound();
            }
            return View(equipamentos);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipamentos equipamentos = db.Equipamento.Find(id);
            db.Equipamento.Remove(equipamentos);
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