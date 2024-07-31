
using StudentSyncBlazor.Core.Wrapper;
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface ICourseExamServices
    {
        Task<List<CourseExamResponseModel>> GetAllCourseExamsAsync();
        Task<CourseExam> GetCourseExamByIdAsync(int id);
        Task<IResult> AddCourseExamAsync(CourseExam courseExam);
        Task<int> UpdateCourseExamAsync(CourseExam courseExam);
        Task<IResult> DeleteCourseExamAsync(int id);
        Task<IResult<IEnumerable<CourseExam>>> SearchCourseExamByCourseIdAsync(int courseId);
        Task<IResult<IEnumerable<CourseExam>>> SearchCourseExamByExamTitleAsync(string examTitle);
        Task<int> GetTotalCourseExamsAsync();

        List<CourseExam> GetAllCourseExamIds();

    }
}
