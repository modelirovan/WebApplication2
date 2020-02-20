using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetAllPositions();
    }
}
