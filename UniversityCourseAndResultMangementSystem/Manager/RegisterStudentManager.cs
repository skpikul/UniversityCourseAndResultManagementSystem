using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class RegisterStudentManager
    {
        private RegisterStudentGateway _registerStudentGateway = new RegisterStudentGateway();

        public int SaveRegisterStuden(RegisterStudentModel registerStudentModel)
        {
            return _registerStudentGateway.InsertRegisterStudent(registerStudentModel);
        }
    }
}