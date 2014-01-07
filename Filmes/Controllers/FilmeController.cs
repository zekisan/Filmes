using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmes.Models;

namespace Filmes.Controllers
{
    public class FilmeController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Filme/

        public ActionResult Index()
        {
            return View(db.Filmes.ToList());
        }

        //
        // GET: /Filme/Details/5

        public ActionResult Details(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // GET: /Filme/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Filme/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        //
        // GET: /Filme/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // POST: /Filme/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        //
        // GET: /Filme/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // POST: /Filme/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult _GenerosForm(string listaGeneros)
        {

            var generos = (from g in db.Generos
                                    orderby g.Nome
                                    select g.Nome).ToList();
            ViewBag.listaGeneros = new SelectList(generos);

            return PartialView("_GenerosForm");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}