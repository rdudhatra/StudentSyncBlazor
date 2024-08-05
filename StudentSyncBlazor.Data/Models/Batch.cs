using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class Batch
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Batch Code is required")]
    public string? BatchCode { get; set; }

    [Required(ErrorMessage = "Batch Time is required")]
    public string? BatchTime { get; set; }

    public int? BatchCourseId { get; set; }

    [Required(ErrorMessage = "Faculty Name is required")]
    public string? FacultyName { get; set; }

    public bool? IsActive { get; set; }

    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }


}

