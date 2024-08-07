using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class Enrollment
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "EnrollmentNo is required.")]
    public string EnrollmentNo { get; set; } = null!;

    [Required(ErrorMessage = "EnrollmentDate is required.")]
    public DateTime? EnrollmentDate { get; set; }

    [Required(ErrorMessage = "BatchId is required.")]
    public int? BatchId { get; set; }

    public int? CourseId { get; set; }

    public int? CourseFeeId { get; set; }

    [Required(ErrorMessage = "InquiryNo is required.")]
    public int? InquiryNo { get; set; }

    public bool? IsActive { get; set; }

    [Required(ErrorMessage = "Remarks is required.")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
