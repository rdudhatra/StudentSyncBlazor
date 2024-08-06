using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSyncBlazor.Data.Models;

public partial class CourseSyllabus
{
    [Key]

    public int Id { get; set; }
    public int? CourseId { get; set; }

    [Required(ErrorMessage = "ChapterName is required")]
    public string? ChapterName { get; set; }

    [Required(ErrorMessage = "TopicName is required")]
    public string? TopicName { get; set; }

    [Required(ErrorMessage = "Remarks is required")]
    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
