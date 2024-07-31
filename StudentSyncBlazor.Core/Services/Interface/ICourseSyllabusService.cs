
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface ICourseSyllabusService
    {
        Task<IEnumerable<CourseSyllabusResponseModel>> GetAllCourseSyllabusesAsync();
        Task<CourseSyllabus> GetCourseSyllabusByIdAsync(int id);
        Task<int> AddCourseSyllabusAsync(CourseSyllabus courseSyllabus);
        Task<int> UpdateCourseSyllabusAsync(CourseSyllabus courseSyllabus);
        Task<bool> DeleteCourseSyllabusAsync(int id);
    }
}
