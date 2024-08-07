using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class StudentAttendance
{
    [Key]

    public int Id { get; set; }
    [Required(ErrorMessage = "AttendanceDate is required.")]
    public DateTime? AttendanceDate { get; set; }

    [Required(ErrorMessage = "EnrollmentNo is required.")]
    public string? EnrollmentNo { get; set; }

    [Required(ErrorMessage = "BatchId is required.")]
    public int? BatchId { get; set; }

    [Required(ErrorMessage = "Remarks is required.")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}


