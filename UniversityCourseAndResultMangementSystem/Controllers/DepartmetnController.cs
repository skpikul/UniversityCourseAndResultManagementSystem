using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class DepartmetnController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        [HttpGet]
        public ActionResult SaveDepartment()
        {
            ViewBag.message = TempData["Msg"];
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(DepartmentModel departmentModel)
        {
            ViewBag.message = departmentManager.InsertDepartmentManager(departmentModel);
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("SaveDepartment");
        }
        public ActionResult ViewAllDepartment()
        {
            List<DepartmentModel> department = departmentManager.GateAllDepertmentManager();
            // ViewBag.ViewDepartment = department;
            return View(department);
        }
    }
}