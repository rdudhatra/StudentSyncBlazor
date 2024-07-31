
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IStudentAttendanceService
    {
        Task<IEnumerable<StudentAttendanceResponseModel>> GetAllStudentAttendances();
        Task<StudentAttendance> GetStudentAttendanceById(int id);
        Task AddStudentAttendance(StudentAttendance studentAttendance);
        Task UpdateStudentAttendance(StudentAttendance studentAttendance);
        Task DeleteStudentAttendance(int id);
        Task<int> GetTotalStudentAttendanceAsync();

    }
}
