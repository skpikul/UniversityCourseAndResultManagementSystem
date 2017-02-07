using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        public List<DesignationModel> GateAllDesignationManager()
        {
            return designationGateway.GateAllDesignationGateway();
        } 
    }
}