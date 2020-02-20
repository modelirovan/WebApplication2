using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.BL.Services;

namespace WebApplication2.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetEmployeesAsync()
        {
            var employees = await _phoneBookService.GetEmployeesAsync();

            return Json(employees);
        }

        public async Task<JsonResult> GetDepartmentsAsync()
        {
            var departments = await _phoneBookService.GetDepartmentsAsync();

            return Json(departments);
        }

        public async Task<JsonResult> GetPositionsAsync()
        {
            var positions = await _phoneBookService.GetPositionsAsync();

            return Json(positions);
        }

        public async Task<JsonResult> SaveEmployeeChangesAsync(int employeeId, string employeeName, string employeePosition, string employeeDepartment)
        {
            var res = await _phoneBookService.ChangeEmployeeAsync(new BL.Models.ChangeEmployeeModel
            {
                Id = employeeId,
                EmployeeName = employeeName,
                EmployeeDepartment = employeeDepartment,
                EmployeePosition = employeePosition
            });

            return Json(res);
        }

        public async Task<JsonResult> AddNewEmployeeAsync(string employeeName, string employeePosition, string employeeDepartment)
        {
            var res = await _phoneBookService.AddNewEmployeeAsync(new BL.Models.AddNewEmployeeModel
            {
                EmployeeDepartment = employeeDepartment,
                EmployeeName = employeeName,
                EmployeePosition = employeePosition
            });

            return Json(res);
        }
    }
}