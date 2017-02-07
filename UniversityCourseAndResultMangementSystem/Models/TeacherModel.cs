using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage ="Enter Teacher Name")]
        [DisplayName("Name")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Enter Teacher Address")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Address")]
        public string TeacherAdderss { get; set; }
        [Required(ErrorMessage = "Enter Teacher Email")]
        [EmailAddress(ErrorMessage = "E-Mail is not valid")]
        [DisplayName("E-Mail")]
        public string TeacherEmail { get; set; }
        [Required(ErrorMessage = "Enter Contact Nunmber")]
        [DisplayName("Contact No.")]
        public string TeacherContactNo { get; set; }
        [Required(ErrorMessage = "Select Designation")]
        [DisplayName("Designation")]
        public int TeacherDesignationId { get; set; }
        [Required(ErrorMessage = "Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Enter Teacher Credit To Taken ")]
        [DisplayName("Credit To Taken")]
        public float TeacherCreditToTaken { get; set; }     

    }
}