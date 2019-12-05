using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model.Model;
using WebApp.BLL.BLL;


namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        // GET: Student
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Add(Student student)
        {
            string message = "Student Information";
            //message += "<br> Roll no: " + student.RollNo;
            //message += "<br> Name:" + student.Name;
            //message += "<br> Department: " + student.DepartmentId;
            if(_studentManager.Add(student))
            {
                message = "Saved";
            }
            else
            {
                message = "Not Saved";
            }
            ViewBag.Message = message;
            return View();
        }
    }
}