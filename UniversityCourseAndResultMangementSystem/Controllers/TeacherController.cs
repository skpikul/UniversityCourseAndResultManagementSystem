using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.message = TempData["Msg"]; 
            ViewBag.Designation = designationManager.GateAllDesignationManager();
            ViewBag.Department = departmentManager.GateAllDepertmentManager();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(TeacherModel teacherModel)
        {
           // ViewBag.Designation = designationManager.GateAllDesignationManager();
            //ViewBag.Department = departmentManager.GateAllDepertmentGateway();
            ViewBag.message = teacherManager.SaveTeacherManager(teacherModel);
            //return View();
                 TempData["Msg"] = ViewBag.message;
                 return RedirectToAction("SaveTeacher");
        }

       
	}
}