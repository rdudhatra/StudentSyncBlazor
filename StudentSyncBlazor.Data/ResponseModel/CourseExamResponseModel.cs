﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Data.ResponseModel
{
    public class CourseExamResponseModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; } 
        public string? ExamTitle { get; set; }
        public string? ExamType { get; set; }
        public int? TotalMarks { get; set; }
        public int? PassingMarks { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
