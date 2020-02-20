using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public async Task<List<Department>> GetAllDepartments()
        {
            return new List<Department>() { new Department { DepartmentName = "Департамент продаж", ID = 1} };
        }
    }
}
