using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.BL.Models;
using WebApplication2.DAL.Entity;

namespace WebApplication2.BL.Services
{
    public interface IPhoneBookService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<Position>> GetPositionsAsync();
        Task<Employee> AddNewEmployeeAsync(AddNewEmployeeModel model);
        Task<Employee> ChangeEmployeeAsync(ChangeEmployeeModel model);
    }
}
