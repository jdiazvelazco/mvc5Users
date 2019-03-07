using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JDVUsers.Models;

namespace JDVUsers.Controllers
{
    [Authorize]
    public class TelefonoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Telefono
        public ActionResult Index()
        {
            var telefonoes = db.Telefonoes.Include(t => t.Contacto);
            return View(telefonoes.ToList());
        }

        // GET: Telefono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefono/Create
        public ActionResult Create()
        {
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre");
            return View();
        }

        // POST: Telefono/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoTelefono,Numero,ContactoID")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefonoes.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", telefono.ContactoID);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", telefono.ContactoID);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoTelefono,Numero,ContactoID")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactoID = new SelectList(db.Contactoes, "Id", "Nombre", telefono.ContactoID);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefonoes.Find(id);
            db.Telefonoes.Remove(telefono);
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
