using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class StudentInstallment
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "ReceiptNo is required.")]
    public string? ReceiptNo { get; set; }

    [Required(ErrorMessage = "ReceiptDate is required.")]
    public DateTime? ReceiptDate { get; set; }

    [Required(ErrorMessage = "Amount is required.")]
    public decimal? Amount { get; set; }
    
    [Required(ErrorMessage = "EnrollmentNo is required.")]
    public string? EnrollmentNo { get; set; }

    [Required(ErrorMessage = "TransactionMode is required.")]
    public string? TransactionMode { get; set; }

    public string? BankName { get; set; }

    public string? Ifsccode { get; set; }

    public string? BranchName { get; set; }

    public string? ChequeTranNo { get; set; }

    [Required(ErrorMessage = "Remarks is required.")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
