using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models
{
    public partial class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(100, ErrorMessage = "Course Name cannot be longer than 100 characters")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "PreRequisite is required")]
        public string PreRequisite { get; set; }

        [Required(ErrorMessage = "Remarks is required")]
        public string Remarks { get; set; }


        [Required(ErrorMessage = "CreatedBy is required")]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
