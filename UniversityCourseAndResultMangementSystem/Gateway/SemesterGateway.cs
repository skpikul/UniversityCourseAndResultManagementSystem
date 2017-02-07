using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class SemesterGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        public List<SemesterModel> GateAllSemesterGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from Semester";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<SemesterModel> semesterModels = new List<SemesterModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    SemesterModel semesterModel = new SemesterModel();
                    semesterModel.SemesterId = Convert.ToInt32(dataReader["SemesterID"]);
                    semesterModel.SemesterName = dataReader["SemiName"].ToString();
                    semesterModels.Add(semesterModel);
                }
                dataReader.Close();
            }
            con.Close();
            return semesterModels;
        } 
    
    }
}