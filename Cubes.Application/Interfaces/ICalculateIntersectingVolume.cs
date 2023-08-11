using static Cubes.Domain.Entities.CubeEntity;

namespace Cubes.Application.Interfaces
{
    public interface ICalculateIntersectingVolume
    {
        public Task<float> CalculateIntersectingCubesVolume(List<Vertice> verticesCube1, List<Vertice> verticesCube2);
    }
}
