using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public string InsertDepartmentManager(DepartmentModel departmentModel)
        {

            if (departmentGateway.IsExisteDepartmentModel(departmentModel) == null)
            {
                int rowAffect = departmentGateway.InsertDepartment(departmentModel);
                if (rowAffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Save Fail!";
                }
            }
            else
            {
                return departmentGateway.IsExisteDepartmentModel(departmentModel);
            }
        }
        public List<DepartmentModel> GateAllDepertmentManager()
        {
            return departmentGateway.GateAllDepertmentGateway();
        } 
    }
}