using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class CourseGateway
    {
        private string conectionStirng = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public int SaveCourseGateway(CourseModel CourseModel)
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "insert into Course values ('" + CourseModel.CourseCode + "', '" + CourseModel.CourseName + "', '" + CourseModel.CourseCredit + "'," +
                           "'" + CourseModel.CourseDescription + "','" + CourseModel.DepartmentId + "', '" + CourseModel.SemesterId + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffect;
        }

        public int SaveCourseAssignGateway(CourseAssignModel courseAssignModel)
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "insert into CourseAssign values ('" + courseAssignModel.DepartmentId + "','" +
                           courseAssignModel.TeacherId + "', '" + courseAssignModel.CourseId + "')";

            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery(); 
            con.Close();
            return rowAffect; 
        }


        public bool IsCourseNameExist(CourseModel courseModel)
        {
            bool isCourseExist = false;
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "Select * from Course where CourseName ='" + courseModel.CourseName + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                isCourseExist = true;
            }
            con.Close();
            return isCourseExist;
        }
        public List<CourseModel> GateAllCourseGateway()
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "select * from Course";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<CourseModel> courseModels = new List<CourseModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    CourseModel courseModel = new CourseModel();
                    courseModel.CourseId = Convert.ToInt32(dataReader["CourseID"]);
                    courseModel.CourseCode = dataReader["CourseCode"].ToString();
                    courseModel.CourseName = dataReader["CourseName"].ToString();
                    courseModel.CourseCredit = Convert.ToDecimal(dataReader["CourseCredit"]);
                    courseModel.CourseDescription = dataReader["CourseDescription"].ToString();
                    courseModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);

                    courseModels.Add(courseModel);
                }
                dataReader.Close();
            }
            con.Close();
            return courseModels;
        }


        public CourseAssignModel GateCourseCredit(int? courseId)
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "Select * from Course where CourseID='" + courseId + "'"; 
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader(); 
            CourseAssignModel courseAssignModel = new CourseAssignModel();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                courseAssignModel.CourseId = Convert.ToInt32(dataReader["CourseID"]);
                courseAssignModel.CourseName = dataReader["CourseName"].ToString();
                courseAssignModel.CourseCredit = Convert.ToDecimal(dataReader["CourseCredit"]); 
                dataReader.Close();
                
            }
            con.Close();
            return courseAssignModel; 
        }

        public List<CourseAssignModel> GatAllViewCourseStaticGateway()
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "select * from vAssignedCourse";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<CourseAssignModel> courseAssignModels = new List<CourseAssignModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    CourseAssignModel courseAssignModel = new CourseAssignModel();
                    courseAssignModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);
                    courseAssignModel.CourseCode = dataReader["CourseCode"].ToString();
                    courseAssignModel.CourseName = dataReader["CourseName"].ToString();
                    courseAssignModel.SemesterName = dataReader["SemiName"].ToString();
                    courseAssignModel.TeacherName = dataReader["AssignedTo"].ToString();

                    courseAssignModels.Add(courseAssignModel);
                }
                dataReader.Close();
            }
            con.Close();
            return courseAssignModels;
        }

    }
}