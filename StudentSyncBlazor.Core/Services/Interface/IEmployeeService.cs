
using StudentSyncBlazor.Core.Wrapper;
using StudentSyncBlazor.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id); 
        Task<IResult> AddEmployeeAsync(Employee employee);
        Task<IResult> UpdateEmployeeAsync(Employee employee);
        Task<IResult> DeleteEmployeeAsync(int id);
        Task<IResult<IEnumerable<Employee>>> SearchEmployeesByNameAsync(string name);

        Task<int> GetTotalEmployeesAsync();

    }
}
