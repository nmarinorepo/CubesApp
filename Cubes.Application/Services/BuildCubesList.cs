using Cubes.Application.Interfaces;
using Cubes.Domain.Entities;
using System.Numerics;
using static Cubes.Domain.Entities.CubeEntity;

namespace Cubes.Application.Services
{
    public class BuildCubesList : IBuildCubesList
    {
        public Task<List<CubeEntity>> buildCubeEntitiesList(string[] input)
        {
            int i = 1;
            List<CubeEntity> cubeEntitiesList = new List<CubeEntity>();
            foreach (var line in input)
            {
                string cubeName = "cube" + i.ToString();

                CubeEntity cube = new CubeEntity
                {
                    Vertices = new Dictionary<string, List<Vertice>>()
                };
                cube.CubeName = cubeName;
                cube.Vertices.Add(cubeName, getCoordinatesFromCenter(line));

                cubeEntitiesList.Add(cube);

                i++;
            }

            return Task.FromResult<List<CubeEntity>>(cubeEntitiesList);
        }

        private List<Vertice> getCoordinatesFromCenter(string input)
        {
            int Xc = int.Parse(input.Split(',')[0]);
            int Yc = int.Parse(input.Split(',')[1]);
            int Zc = int.Parse(input.Split(',')[2]);
            int SL = int.Parse(input.Split(',')[3]);

            Vertice frontRU = new Vertice() { VerticeName = "frontRightUpper", Coordinates = new Vector3(Xc + SL / 2, Yc + SL / 2, Zc + SL / 2) };
            Vertice bottomRU = new Vertice() { VerticeName = "bottomRightUpper", Coordinates = new Vector3(Xc + SL / 2, Yc + SL / 2, Zc - SL / 2) };
            Vertice frontRL = new Vertice() { VerticeName = "frontRightLower", Coordinates = new Vector3(Xc + SL / 2, Yc - SL / 2, Zc + SL / 2) };
            Vertice bottomRL = new Vertice() { VerticeName = "bottomRightLower", Coordinates = new Vector3(Xc + SL / 2, Yc - SL / 2, Zc - SL / 2) };

            Vertice frontLU = new Vertice() { VerticeName = "frontLeftUpper", Coordinates = new Vector3(Xc - SL / 2, Yc + SL / 2, Zc + SL / 2) };
            Vertice bottomLU = new Vertice() { VerticeName = "bottomLeftUpper", Coordinates = new Vector3(Xc - SL / 2, Yc + SL / 2, Zc - SL / 2) };
            Vertice frontLL = new Vertice() { VerticeName = "frontLeftLower", Coordinates = new Vector3(Xc - SL / 2, Yc - SL / 2, Zc + SL / 2) };
            Vertice bottomLL = new Vertice() { VerticeName = "bottomLeftLower", Coordinates = new Vector3(Xc - SL / 2, Yc - SL / 2, Zc - SL / 2) };

            return new List<Vertice>() { frontRU, bottomRU, frontRL, bottomRL, frontLU, bottomLU, frontLL, bottomLL };
        }
    }
}
