using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();

        public List<SemesterModel> GateAllSemesterManager()
        {
            return semesterGateway.GateAllSemesterGateway();
        }

    }
}