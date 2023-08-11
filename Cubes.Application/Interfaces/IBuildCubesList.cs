using Cubes.Domain.Entities;

namespace Cubes.Application.Interfaces
{
    public interface IBuildCubesList
    {
        Task<List<CubeEntity>> buildCubeEntitiesList(string[] input);
    }
}
