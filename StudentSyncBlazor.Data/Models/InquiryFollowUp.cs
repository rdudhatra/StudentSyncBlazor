using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class InquiryFollowUp
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "InquiryDate is required.")]
    public DateTime? InquiryDate { get; set; }

    [Required(ErrorMessage = "InquiryNo is required.")]
    public int? InquiryNo { get; set; }

    [Required(ErrorMessage = "Through is required.")]
    public string? Through { get; set; }

    [Required(ErrorMessage = "Remarks is required.")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
