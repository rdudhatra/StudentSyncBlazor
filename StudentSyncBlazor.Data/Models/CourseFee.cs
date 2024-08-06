using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class CourseFee
{
    [Key]
    public int Id { get; set; }

    public int? CourseId { get; set; }

    [Required(ErrorMessage = "TotalFees is required")]
    public decimal? TotalFees { get; set; }
    [Required(ErrorMessage = "DownPayment is required")]
    public decimal? DownPayment { get; set; }
    [Required(ErrorMessage = "NoofInstallment is required")]
    public int? NoofInstallment { get; set; }
    [Required(ErrorMessage = "InstallmentAmount is required")]
    public decimal? InstallmentAmount { get; set; }

    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
