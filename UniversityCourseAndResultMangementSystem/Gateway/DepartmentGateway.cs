using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class DepartmentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public int InsertDepartment(DepartmentModel saveDepartment)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into Department values('" + saveDepartment.Name + "','" +
                           saveDepartment.Code + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffect;
        }

        public string IsExisteDepartmentModel(DepartmentModel departmentModel)
        {
            string message = null;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from Department where DepartName = '" + departmentModel.Name + "' OR DepartCode = '" + departmentModel.Code + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                message = "This Name OR Code Already Existe";
            }
            return message;
        }

        public List<DepartmentModel> GateAllDepertmentGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from Department";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<DepartmentModel> saveDepartments = new List<DepartmentModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    DepartmentModel departmentModel = new DepartmentModel();
                    departmentModel.DepartmentID = Convert.ToInt32(dataReader["DepartmentID"]);
                    departmentModel.Name = dataReader["DepartName"].ToString();
                    departmentModel.Code = dataReader["DepartCode"].ToString();
                    saveDepartments.Add(departmentModel);
                }
                dataReader.Close();
            }
            con.Close();
            return saveDepartments;
        }
    }
}