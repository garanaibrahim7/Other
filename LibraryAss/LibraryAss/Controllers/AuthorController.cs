using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAss.Models;
using System.Data;

namespace AssQ2.Controllers
{
    public class AuthorController : Controller
    {
        DBManager db = new DBManager();
        // GET: Author
        public ActionResult Index()
        {
            string query = @"SELECT a.aid, a.aname, a.expertise, p.pname 
                             FROM Author a 
                             INNER JOIN Publisher p ON a.pid = p.pid";
            DataTable dt = db.GetDataTable(query);
            return View(dt);
        }
        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            DataTable publishers = db.GetDataTable("SELECT * FROM Publisher");
            ViewBag.Publishers = publishers;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string aname = collection["aname"];
                int pid = Convert.ToInt32(collection["pid"]);
                string expertise = collection["expertise"];

                string query = $"INSERT INTO Author (aname, pid, expertise) VALUES ('{aname}', {pid}, '{expertise}')";
                db.ExecuteNonQuery(query);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                DataTable publishers = db.GetDataTable("SELECT * FROM Publisher");
                ViewBag.Publishers = publishers;
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}