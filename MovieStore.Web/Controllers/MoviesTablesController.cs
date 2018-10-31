using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieStore.Web.Models;
using MovieStore.Business;

namespace MovieStore.Web.Controllers
{
    public class MoviesTablesController : Controller
    {
        private MovieStoreDB db = new MovieStoreDB();

        // GET: MoviesTables
        public ActionResult Index()
        {
            return View(db.MoviesTable.ToList());
        }

        public ActionResult Cart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MoviesTable moviesTable = db.MoviesTable.Find(id);
            if (moviesTable == null)
            {
                return HttpNotFound();
            }

            //ViewBag.Tax = moviesTable.Price * 0.08; Replace with call to .Business project
            Calc cl = new Calc();

            ViewBag.Tax = cl.GetTax(moviesTable.Price);
            ViewBag.Total = cl.GetTotal(moviesTable.Price);
            return View("~/Views/MoviesTables/Cart.cshtml", moviesTable);
        }

        // GET: MoviesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesTable moviesTable = db.MoviesTable.Find(id);
            if (moviesTable == null)
            {
                return HttpNotFound();
            }
            return View(moviesTable);
        }

        // GET: MoviesTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,YearRelasesed,Price,GenreId")] MoviesTable moviesTable)
        {
            if (ModelState.IsValid)
            {
                db.MoviesTable.Add(moviesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviesTable);
        }

        // GET: MoviesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesTable moviesTable = db.MoviesTable.Find(id);
            if (moviesTable == null)
            {
                return HttpNotFound();
            }
            return View(moviesTable);
        }

        // POST: MoviesTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,YearRelasesed,Price,GenreId")] MoviesTable moviesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviesTable);
        }

        // GET: MoviesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesTable moviesTable = db.MoviesTable.Find(id);
            if (moviesTable == null)
            {
                return HttpNotFound();
            }
            return View(moviesTable);
        }

        // POST: MoviesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviesTable moviesTable = db.MoviesTable.Find(id);
            db.MoviesTable.Remove(moviesTable);
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
