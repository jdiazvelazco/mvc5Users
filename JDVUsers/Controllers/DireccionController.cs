using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JDVUsers.Models;
using JDVusers.Models;

namespace JDVUsers.Controllers
{
    [Authorize]
    public class DireccionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Direccion
        public ActionResult Index()
        {
            var direccions = db.Direccions.Include(d => d.Contacto);
            return View(direccions.ToList());
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre");
            return View();
        }

        // POST: Direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoDireccion,Pais,Ciudad,Estado,Colonia,Calle,Numero,CodigoPostal,ContactoID")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccions.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", direccion.ContactoID);
            return View(direccion);
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", direccion.ContactoID);
            return View(direccion);
        }

        // POST: Direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoDireccion,Pais,Ciudad,Estado,Colonia,Calle,Numero,CodigoPostal,ContactoID")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", direccion.ContactoID);
            return View(direccion);
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.Direccions.Find(id);
            db.Direccions.Remove(direccion);
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
