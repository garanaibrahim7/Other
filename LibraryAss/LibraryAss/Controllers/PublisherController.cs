using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAss.Models;

namespace AssQ2.Controllers
{
    public class PublisherController : Controller
    {
        DBManager db = new DBManager();
        // GET: Publisher
        public ActionResult Index()
        {
            DataTable dt = db.GetDataTable("SELECT * FROM Publisher");
            ViewBag.Data = dt;
            return View();
        }
        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string pname = collection["pname"];
                string city = collection["city"];

                string query = $"INSERT INTO Publisher (pname, city) VALUES ('{pname}', '{city}')";
                if (db.ExecuteNonQuery(query) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dt = db.GetDataTable("SELECT * FROM Publisher WHERE pid=" + id);
            if (dt.Rows.Count == 1)
            {
                ViewBag.pid = dt.Rows[0]["pid"];
                ViewBag.pname = dt.Rows[0]["pname"];
                ViewBag.city = dt.Rows[0]["city"];
                return View();
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string pname = collection["pname"];
                string city = collection["city"];

                string query = "UPDATE Publisher SET pname = '" + pname + "', city = '" +city+ "' WHERE pid = "+id;
                
                if (db.ExecuteNonQuery(query) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                string query = "DELETE FROM Publisher WHERE pid = " + id;

                if (db.ExecuteNonQuery(query) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }        
    }
}