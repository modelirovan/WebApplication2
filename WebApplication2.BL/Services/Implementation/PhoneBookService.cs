using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.BL.Models;
using WebApplication2.DAL.Entity;
using WebApplication2.DAL.Repository;

namespace WebApplication2.BL.Services.Implementation
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public PhoneBookService(IDepartmentRepository departmentRepository,
            IPositionRepository positionRepository,
            IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
            _employeeRepository = employeeRepository;
        }


        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployee();
            return employees;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartments();

            return departments;
        }

        public async Task<List<Position>> GetPositionsAsync()
        {
            var positions = await _positionRepository.GetAllPositions();

            return positions;
        }

        public async Task<Employee> AddNewEmployeeAsync(AddNewEmployeeModel model)
        {
            var res = await _employeeRepository.AddNewEmployeeAsync(new Employee
            {
                FIO = model.EmployeeName,
                DepartmentName = model.EmployeeDepartment,
                PositionName = model.EmployeePosition
            });

            return res;
        }

        public async Task<Employee> ChangeEmployeeAsync(ChangeEmployeeModel model)
        {
            var res = await _employeeRepository.ChangeEmployeeAsync(new Employee
            {
                ID = model.Id,
                DepartmentName = model.EmployeeDepartment,
                FIO = model.EmployeeName,
                PositionName = model.EmployeePosition
            });

            return res;
        }
    }
}
