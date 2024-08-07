using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class StudentAssessment
{
    [Key]

    public int Id { get; set; }
    [Required(ErrorMessage = "Assessment Date is required.")]
    public DateTime? AssessmentDate { get; set; }

    [Required(ErrorMessage = "EnrollmentNo is required.")]
    public string? EnrollmentNo { get; set; }

    [Required(ErrorMessage = "CourseExamId is required.")]
    public int? CourseExamId { get; set; }

    [Required(ErrorMessage = "ObtainedMarks is required.")]
    public decimal? ObtainedMarks { get; set; }

    [Required(ErrorMessage = "Remarks is required.")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
