using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        List<Employee> employees = new List<Employee>()
            {
                new Employee { ID = 1, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 2, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 3, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 4, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 5, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 6, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 7, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" },
                new Employee { ID = 8, DepartmentName = "Департамент продаж", FIO = "Иванов Иван Иванович", PositionName = "Директор" }
            };
        public async Task<List<Employee>> GetAllEmployee()
        {
            return employees;
        }

        public async Task<Employee> AddNewEmployeeAsync(Employee employee)
        {
            employees.Add(new Employee
            {
                FIO = employee.FIO,
                DepartmentName = employee.DepartmentName,
                PositionName = employee.PositionName,
                ID = employees.Count + 1
            });

            var res = employees.LastOrDefault();

            return res;
        }

        public async Task<Employee> ChangeEmployeeAsync(Employee employee)
        {
            var res = employees.Where(x => x.ID == employee.ID).FirstOrDefault();

            if (res != null)
            {
                res.DepartmentName = employee.DepartmentName;
                res.FIO = employee.FIO;
                res.PositionName = employee.PositionName;
            }

            return res;
        }
    }
}
