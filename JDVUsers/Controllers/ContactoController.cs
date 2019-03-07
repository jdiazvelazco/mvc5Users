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
    public class ContactoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacto
        public ActionResult Index()
        {
            return View(db.Contactoes.ToList());
        }

        public ActionResult NewContacto()
        {
            var contacto = new Contacto();

            return View(contacto);
        }
        //public ActionResult ContactoDemo(Contacto contacto,List<Telefono> telefonos)
        //{
        //    db.Contactoes.Add(contacto);
        //    db.SaveChanges();
        //    int id = db.Contactoes.FirstOrDefault(s => s.RFC == contacto.RFC).Id;
        //    foreach (var detail in telefonos)
        //    {
        //        detail.ContactoID = id;
        //    }
        //    db.Telefonoes.AddRange(telefonos );
        //    db.SaveChanges();
        //    return View();
        //    //return View(db.Contactoes.ToList());
        //}
        //public ActionResult ContactoTelefonoDemo(int? i)
        //{
        //    ViewBag.i = i;
        //    return PartialView();
        //}


        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contacto modelo,  string operacion = null)
        {
            if (modelo == null)
            {
                modelo = new Contacto();
            }

            if (operacion == null)
            {

                var numero = Request["Numero"];
                var tipo = Request["TipoTelefono"];
                Telefono telefono = new Telefono();
                telefono.Numero = numero;
                telefono.TipoTelefono = (TipoTelefono)(int.Parse(tipo));
                modelo.Telefonos.Add(telefono);

                string[] numeros = Request.Form.GetValues("Numero");


                if (CrearContacto(modelo))
                {
                    return RedirectToAction("Index");
                }
            }
            else if (operacion == "agregar-telefono")
            {
                var tel = new Telefono();

                modelo.Telefonos.Add(tel);
            }
            else if (operacion == "agregar-direccion")
            {
                var dir = new Direccion();
                modelo.Direcciones.Add(dir);
            }
            //else if (operacion.StartsWith("eliminar-telefono-"))
            //{
            //    EliminarDetallePorIndice(modelo, operacion);
            //}

            //ViewBag.Productos = productos;
            return View(modelo);
        }

        private bool CrearContacto(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                if (contacto.Telefonos != null && contacto.Telefonos.Count > 0)
                {
                    db.Contactoes.Add(contacto);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "No puede guardar contactos sin telefonos");
                }
            }

            return false;
        }

        // POST: Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nombre,TipoContacto,CorreoElectronico,RFC")] Contacto contacto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Contactoes.Add(contacto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(contacto);
        //}

        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,TipoContacto,CorreoElectronico,RFC")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.Contactoes.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.Contactoes.Find(id);
            db.Contactoes.Remove(contacto);
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
