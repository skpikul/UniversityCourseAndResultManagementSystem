using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class CourseAssignController : Controller
    {
       DepartmentManager departmentManager = new DepartmentManager();
       TeacherManager teacherManager = new TeacherManager();
       CourseManager courseManager = new CourseManager();
        [HttpGet]
       public ActionResult SaveCourseAssign()
        {
            ViewBag.DepartmentList = departmentManager.GateAllDepertmentManager();
           // ViewBag.TeacherList = teacherManager.GateAllTeacherManager(); 
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourseAssign(CourseAssignModel courseAssignModel)
        {
            ViewBag.message = courseManager.SaveCourseAssignManager(courseAssignModel); 
            ViewBag.DepartmentList = departmentManager.GateAllDepertmentManager();
            return View(); 
        }
        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teacher = teacherManager.GateAllTeacherManager();
            var teacherList = teacher.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var course = courseManager.GateAllCourseManager();
            var courseList = course.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult CreditTakenByTeacher(int? teacherId)
        {
            CourseAssignModel courseTeacher = teacherManager.GatTeacherCreditManger(teacherId);
            return Json(courseTeacher, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult CreditTakenByCourseId(int? passCourse)
        {
            CourseAssignModel courseCredit = courseManager.GateCourseCredit(passCourse);
            return Json(courseCredit, JsonRequestBehavior.AllowGet); 
        }
        public ActionResult ViewCourseStatic()
        {
            ViewBag.departmentList = departmentManager.GateAllDepertmentManager();
         // ViewBag.courseStatic = courseManager.GatAllViewCourseStaticManager(); 
            return View(); 
        }
        public JsonResult ViewCourseStaticByDepartmentId(int? departmentId)
        {
            var courseStatic = courseManager.GatAllViewCourseStaticManager();
            var getCourseStatic = courseStatic.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(getCourseStatic, JsonRequestBehavior.AllowGet); 
        } 
	}
}