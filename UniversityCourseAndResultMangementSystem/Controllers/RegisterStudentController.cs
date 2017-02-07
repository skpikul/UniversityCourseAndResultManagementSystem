using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class RegisterStudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        RegisterStudentManager _registerStudentManager = new RegisterStudentManager();
        // GET: RegisterStudent
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DepartmentList = departmentManager.GateAllDepertmentManager();
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterStudentModel registerStudent)
        {
            ViewBag.Data = _registerStudentManager.SaveRegisterStuden(registerStudent);
            departmentManager.GateAllDepertmentManager();
            return View();
        }
    }
}