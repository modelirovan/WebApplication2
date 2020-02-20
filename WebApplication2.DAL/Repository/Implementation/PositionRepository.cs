using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DAL.Entity;

namespace WebApplication2.DAL.Repository.Implementation
{
    public class PositionRepository : IPositionRepository
    {
        public async Task<List<Position>> GetAllPositions()
        {
            return new List<Position>
            {
                new Position
                {
                    ID = 1,
                    PositionName = "Директор департамента"
                }
            };
        }
    }
}
