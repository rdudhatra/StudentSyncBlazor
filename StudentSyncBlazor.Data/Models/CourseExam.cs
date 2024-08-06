using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class CourseExam
{
    [Key]

    public int Id { get; set; }

    public int? CourseId { get; set; }

    [Required(ErrorMessage = "ExamTitle is required")]
    public string? ExamTitle { get; set; }

    [Required(ErrorMessage = "ExamType is required")]
    public string? ExamType { get; set; }

    [Required(ErrorMessage = "TotalMarks is required")]
    public int? TotalMarks { get; set; }

    [Required(ErrorMessage = "PassingMarks is required")]
    public int? PassingMarks { get; set; }
    [Required(ErrorMessage = "Remarks is required")]

    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
