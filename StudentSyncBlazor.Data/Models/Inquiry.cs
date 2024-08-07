using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class Inquiry
{
    [Key]
    public int InquiryNo { get; set; }

    [Required(ErrorMessage = "InquiryDate is required.")]
    public DateTime? InquiryDate { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "FirstName is required.")]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "LastName is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "ContactNo is required.")]
    public string? ContactNo { get; set; }

    [Required(ErrorMessage = "EmailId is required.")]
    public string? EmailId { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public string? Reference { get; set; }

    public bool? Job { get; set; }

    public bool? Business { get; set; }

    public bool? Study { get; set; }

    public string? Other { get; set; }

    public bool? PrevCompCourse { get; set; }

    public string? PrevCompCourseDetails { get; set; }

    public int? CourseId { get; set; }


    public string? Note { get; set; }

    public string? EnquiryType { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
