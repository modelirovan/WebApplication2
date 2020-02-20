using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> AddNewEmployeeAsync(Employee employee);
        Task<Employee> ChangeEmployeeAsync(Employee employee);
    }
}
