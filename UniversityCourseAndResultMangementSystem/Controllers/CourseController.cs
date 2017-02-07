using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager();
        SemesterManager semesterManager = new SemesterManager();
        DepartmentManager departmentManager = new DepartmentManager();


        public ActionResult SaveCourse()
        {
            ViewBag.message = TempData["Msg"];
            ViewBag.DepartmentList = departmentManager.GateAllDepertmentManager();
            ViewBag.SemesterList = semesterManager.GateAllSemesterManager();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(CourseModel courseModel)
        {
                ViewBag.message = courseManager.SaveCourseManager(courseModel);
                //ViewBag.DepartmentList = departmentManager.GateAllDepertmentGateway();
                //ViewBag.SemesterList = semesterManager.GateAllSemesterManager();
                //return View();
                TempData["Msg"] = ViewBag.message;
                return RedirectToAction("SaveCourse");
        }
	
	}
}