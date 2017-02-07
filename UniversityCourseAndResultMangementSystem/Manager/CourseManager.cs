using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI.WebControls;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();

        public string SaveCourseManager(CourseModel courseModel)
        {
            if (courseGateway.IsCourseNameExist(courseModel))
            {
                return "Is Course Name Already Exist";
            }
            if (courseGateway.SaveCourseGateway(courseModel) > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save Fail";
            }
        }

        public List<CourseModel> GateAllCourseManager()
        {
            return courseGateway.GateAllCourseGateway();
        }

        public string SaveCourseAssignManager(CourseAssignModel courseAssignModel)
        {
            int rowAffect = courseGateway.SaveCourseAssignGateway(courseAssignModel);
            if (rowAffect > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save Fail"; 
            }
        }

        public CourseAssignModel GateCourseCredit(int? courseId)
        {
            return courseGateway.GateCourseCredit(courseId); 
        }

        public List<CourseAssignModel> GatAllViewCourseStaticManager()
        {
            return courseGateway.GatAllViewCourseStaticGateway(); 
        } 
    }
}