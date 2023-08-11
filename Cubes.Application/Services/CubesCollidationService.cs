using Cubes.Application.Interfaces;
using Cubes.Domain.Entities;
using static Cubes.Domain.Entities.CubeEntity;

namespace Cubes.Application.Services
{
    public class CubesCollidationService : ICubesCollidationService
    {
        private readonly IBuildCubesList _buildCubesList;
        private readonly ICalculateIntersectingVolume _calculateIntersectingVolume;
        List<Vertice> verticesCube1, verticesCube2;

        public CubesCollidationService(IBuildCubesList buildCubesList, ICalculateIntersectingVolume calculateIntersectingVolume)
        {
            _buildCubesList = buildCubesList;
            _calculateIntersectingVolume = calculateIntersectingVolume;
        }

        public async Task<Response> getIntersectingCubesVolume(string[] input)
        {
            Response resp = new Response() { areCubesCollident = false, volume = 0 };

            List<CubeEntity> cubeEntities = await _buildCubesList.buildCubeEntitiesList(input);

            CubeEntity cube1 = cubeEntities.Where(x => x.CubeName.Equals("cube1")).FirstOrDefault();
            CubeEntity cube2 = cubeEntities.Where(x => x.CubeName.Equals("cube2")).FirstOrDefault();
                        

            cube1.Vertices.TryGetValue("cube1", out verticesCube1);
            Vertice coordsCube1 = verticesCube1.Where(x => x.VerticeName.Equals("frontRightUpper")).FirstOrDefault();

            cube2.Vertices.TryGetValue("cube2", out verticesCube2);
            Vertice coordsCube2 = verticesCube2.Where(x => x.VerticeName.Equals("frontLeftUpper")).FirstOrDefault();

            if ((coordsCube1.Coordinates.X > coordsCube2.Coordinates.X) || (coordsCube1.Coordinates.Y > coordsCube2.Coordinates.Y) || (coordsCube1.Coordinates.Z > coordsCube2.Coordinates.Z))
            {
                resp.volume = await _calculateIntersectingVolume.CalculateIntersectingCubesVolume(verticesCube1, verticesCube2);
                resp.areCubesCollident = resp.volume > 0;
            }

            return resp;
        }        
    }
}
