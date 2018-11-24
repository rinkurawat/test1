using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.DB;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            DBAccess db = new DBAccess();


            return View(db.GetEmp());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emp/Create
        public ActionResult Create()
        {

            //Fill Gender 
            List<SelectListItem> Gender = new List<SelectListItem>() {
                new SelectListItem{ Text="Select Gender",Value="-1"},
                new SelectListItem{ Text="Male",Value="1"},
                new SelectListItem{ Text="Female",Value="2"}
            };
            //ViewBag.Gender = Gender;
            //ViewData["Gender"] = Gender;
            //TempData["Gender"] = Gender;

            //Fill State
            DBAccess db = new DBAccess();
            var fromDatabase = new SelectList(db.GetState(), "StateID", "Name");
            TempData["State"] = fromDatabase;
          
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Emp  emp)
        {
            try
            {
                // TODO: Add insert logic here
                DBAccess db = new DBAccess();
                db.AddEmp(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emp/Edit/5
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

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emp/Delete/5
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
