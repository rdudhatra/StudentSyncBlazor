using System.Collections.Generic;
using System.Threading.Tasks;

using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface ICourseFeeService
    {
        Task<List<CourseFeeResponseModel>> GetAllCourseFeesAsync();
        Task<CourseFee> GetCourseFeeByIdAsync(int id);
        Task<int> AddCourseFeeAsync(CourseFee courseFee);
        Task<int> UpdateCourseFeeAsync(CourseFee courseFee);
        Task<bool> DeleteCourseFeeAsync(int id);
        List<CourseFee> GetAllCourseExamIds();
        Task<int> GetTotalCourseFeesAsync();

    }
}
 