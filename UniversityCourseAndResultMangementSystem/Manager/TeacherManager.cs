using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();

        public string SaveTeacherManager(TeacherModel teacherModel)
        {
            if (teacherGateway.SaveTeacherGateway(teacherModel) > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save Fail";
            }
        }

        public List<TeacherModel> GateAllTeacherManager()
        {
            return teacherGateway.GateAllTeacherGateway();
        }

        public CourseAssignModel GatTeacherCreditManger(int? teacherId)
        {
            return teacherGateway.GatTeacherCreditGateway(teacherId); 
        }
    }
}