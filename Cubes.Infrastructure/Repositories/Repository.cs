using Cubes.Domain.Entities;
using Cubes.Domain.Interfaces.Repositories;

namespace Cubes.Infrastructure.Data.Repositories
{
    public class Repository : IRepository<ResponseEntity>
    {
        public bool Save(ResponseEntity entity)
        {
            // TODO: Some kind of persistance...
            return true;
        }
    }
}
