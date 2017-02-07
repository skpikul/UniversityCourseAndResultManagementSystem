using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class RegisterStudentGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public int InsertRegisterStudent(RegisterStudentModel registerStudentModel)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO RegisterStudent VALUES ('" + registerStudentModel.StudentId + "','" + registerStudentModel.Name + "','" + registerStudentModel.Email + "','" + registerStudentModel.ContactNo + "', '" + registerStudentModel.Date + "''" + registerStudentModel.Address + "','" + registerStudentModel.DepartmentId + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

    }
}