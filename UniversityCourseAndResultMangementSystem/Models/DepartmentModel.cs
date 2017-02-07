using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class DepartmentModel
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Code are Required")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "code must be two (2) to seven (7) characters long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Department Code are Required")]
        public string Name { get; set; }
    }
}