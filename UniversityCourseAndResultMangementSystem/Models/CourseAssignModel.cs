using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class CourseAssignModel
    {
        public int  CourseAssignId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public decimal TeacherCreditToTaken { get; set; }
        public decimal TeacherRemainingCredit { get; set; }
        public string TeacherName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
        public string SemesterName { get; set; }
        public string AssignFlag { get; set; }
    }
}