using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class DesignationGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public List<DesignationModel> GateAllDesignationGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Designation";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<DesignationModel> designationModels = new List<DesignationModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    DesignationModel designationModel = new DesignationModel();
                    designationModel.DesignationId = Convert.ToInt32(dataReader["DesignationId"]);
                    designationModel.DesignationName = dataReader["DesignationName"].ToString();
                    designationModels.Add(designationModel);
                }
                dataReader.Close();
            }
            con.Close();
            return designationModels;

        } 
    }
}