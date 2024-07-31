﻿using StudentSyncBlazor.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interfaces
{
    public interface IStudentInstallmentService
    {
        Task<IEnumerable<StudentInstallment>> GetAllStudentInstallmentsAsync();
        Task<StudentInstallment> GetStudentInstallmentByIdAsync(int id);
        Task<int> CreateStudentInstallmentAsync(StudentInstallment studentInstallment);
        Task<int> UpdateStudentInstallmentAsync(StudentInstallment studentInstallment);
        Task DeleteStudentInstallmentAsync(int id);
    }
}
