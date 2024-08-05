using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class Employee
{
    [Key]

    public int Id { get; set; }
    [Required(ErrorMessage = "First Name is required.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    public DateTime? DoB { get; set; }

    [Required(ErrorMessage = "Qualification is required.")]
    public string? Qualification { get; set; }

    [Required(ErrorMessage = "Designation is required.")]
    public string? Designation { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
