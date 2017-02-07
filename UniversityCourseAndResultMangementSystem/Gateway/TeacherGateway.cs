using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class TeacherGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        public int SaveTeacherGateway(TeacherModel teacherModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into Teacher values ('" + teacherModel.TeacherName + "','" +
                           teacherModel.TeacherAdderss + "','" + teacherModel.TeacherEmail + "','" +
                           teacherModel.TeacherContactNo + "','" + teacherModel.TeacherDesignationId + "','" +
                           teacherModel.DepartmentId + "','" + teacherModel.TeacherCreditToTaken + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            return rowAffect;
        }

        public List<TeacherModel> GateAllTeacherGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Teacher";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TeacherModel teacherModel = new TeacherModel();
                    teacherModel.TeacherId = Convert.ToInt32(dataReader["TeacherID"]);
                    teacherModel.TeacherName = dataReader["TeacherName"].ToString();
                    teacherModel.TeacherAdderss = dataReader["TeacherAddress"].ToString();
                    teacherModel.TeacherEmail = dataReader["TeacherEmail"].ToString();
                    teacherModel.TeacherContactNo = dataReader["TeacherPhone"].ToString();
                    teacherModel.TeacherDesignationId = Convert.ToInt32(dataReader["DesignationID"]);
                    teacherModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);
                    teacherModels.Add(teacherModel);
                }
                dataReader.Close();
            }
            con.Close();
            return teacherModels;
        }




        public CourseAssignModel GatTeacherCreditGateway(int? teacherId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from vTeacherCourse where TeacherID='" + teacherId + "'"; 
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            CourseAssignModel courseAssignModel = new CourseAssignModel();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                courseAssignModel.CourseId = Convert.ToInt32(dataReader["TeacherID"]);
                courseAssignModel.TeacherCreditToTaken = Convert.ToDecimal(dataReader["CreditTaken"]);
                courseAssignModel.TeacherRemainingCredit = Convert.ToDecimal(dataReader["RemCredit"]); 
                dataReader.Close();
                }
            con.Close();
            return courseAssignModel; 
        }
    }
}