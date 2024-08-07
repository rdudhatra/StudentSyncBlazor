using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interfaces
{
    public interface IStudentInstallmentService
    {
        Task<IEnumerable<StudentInstallmentResponseModel>> GetAllStudentInstallmentsAsync();
        Task<StudentInstallment> GetStudentInstallmentByIdAsync(int id);
        Task<int> CreateStudentInstallmentAsync(StudentInstallment studentInstallment);
        Task<int> UpdateStudentInstallmentAsync(StudentInstallment studentInstallment);
        Task DeleteStudentInstallmentAsync(int id);
        Task<int> GetTotalStudentInstallMentAsync();

    }
}
