using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class RegisterStudentModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is must currect Format")]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public int DepartmentId { get; set; }

    }
}