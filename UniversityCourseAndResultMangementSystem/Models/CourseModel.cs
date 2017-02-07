using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Enter Course Code")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Course Code must be 5 characters long")]
        [DisplayName("Code")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Enter Course Name")]
        [DisplayName("Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Enter Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit Range 0.5 to 5.0")]
        [DisplayName("Credit")]
        public decimal CourseCredit { get; set; }
        [Required(ErrorMessage = "Enter Course Desicription")]
        [DisplayName("Description")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "Select a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Select a Semester")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }
    }
}