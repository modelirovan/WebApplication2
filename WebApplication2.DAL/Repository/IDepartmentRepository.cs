using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
    }
}
