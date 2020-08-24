using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Data.Entity.Migrations;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        
        // GET: Student
        public ActionResult Index()

        {
            
          
            List<Student> students = db.Students.ToList();
            
            return View(students);
            

            //}
            //return null;
        }

        public ActionResult Detail(int? id)
        {

          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student course = db.Students.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }



        //[HttpPost]
        //// [ValidateAntiForgeryToken]
        //public ActionResult Create(Student student)

        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Students.Add(student);
        //            db.SaveChanges();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (RetryLimitExceededException)
        //    {

        //        //Log the error (uncomment dex variable name and add a line here to write a log.)
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }
        //    return View(student);
        //}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.SingleOrDefault(m => m.Id == id);
            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(student);
        }
        [HttpPost]

        public ActionResult Edit(Student student)


        {

            if (ModelState.IsValid)
            {
                db.Students.AddOrUpdate(student);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }




            return Edit(student);
        }
        public ActionResult Delete(int? id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);

            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public JsonResult Add(string name, string email, string address, string phone)
        {
            Student student = new Student();

            student.Name = name;
            student.Email = email;
            student.Address = address;
            student.Telephone = phone;
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return Json("as");
        }

        // Pass 1 model into Controller
        //public JsonResult Add(Student student)
        //{

        //    db.Students.AddOrUpdate(student);
        //    db.SaveChanges();
        //    return Json(student);
        //    }
        [HttpPost]
        public JsonResult Update(int id, string name, string email, string address, string phone)
        {
            Student student = new Student();
            student.Id = id;
            student.Name = name;
            student.Email = email;
            student.Address = address;
            student.Telephone = phone;
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return Json("as");
        }
        [HttpPost]

        public JsonResult Delete1(int id)
        {
          
            Student student = db.Students.Find(id);

            db.Students.Remove(student);
            db.SaveChanges();
            return Json("");

        }

    }

}