using Cubes.Application.Interfaces;
using System.Numerics;
using static Cubes.Domain.Entities.CubeEntity;

namespace Cubes.Application.Services
{
    public class CalculateIntersectingVolume : ICalculateIntersectingVolume
    {
        List<Vertice> _verticesCube1, _verticesCube2;
        public Task<float> CalculateIntersectingCubesVolume(List<Vertice> verticesCube1, List<Vertice> verticesCube2)
        {
            _verticesCube1 = verticesCube1;
            _verticesCube2 = verticesCube2;

            Vector3 vect = getMinimumCoordinateByCorner("frontRightUpper");
            float XmaxCube1 = vect.X;

            vect = getMaximumCoordinateByCornerName("frontLeftUpper");
            float XminCube2 = vect.X;

            float Xlenght = XmaxCube1 - XminCube2;


            vect = getMaximumCoordinateByCornerName("bottomLeftUpper");
            float YmaxCube1 = vect.Y;


            vect = getMaximumCoordinateByCornerName("bottomLeftLower");
            float YminCube2 = vect.Y;

            float Ylenght = YmaxCube1 - YminCube2;


            vect = getMaximumCoordinateByCornerName("frontLeftLower");
            float ZmaxCube1 = vect.Z;


            vect = getMaximumCoordinateByCornerName("bottomLeftLower");
            float ZminCube2 = vect.Z;

            float Zlenght = ZmaxCube1 - ZminCube2;

            var volume = Xlenght * Ylenght * Zlenght;
            return Task.FromResult<float>(volume);
        }

        private Vector3 getMaximumCoordinateByCornerName(string cornerName)
        {
            Vector3 vector = new Vector3();
            Vertice coords1 = _verticesCube1.Where(x => x.VerticeName.Equals(cornerName)).FirstOrDefault();
            Vertice coords2 = _verticesCube2.Where(x => x.VerticeName.Equals(cornerName)).FirstOrDefault();

            vector.X = MathF.Max(coords1.Coordinates.X, coords2.Coordinates.X);
            vector.Y = MathF.Max(coords1.Coordinates.Y, coords2.Coordinates.Y);
            vector.Z = MathF.Max(coords1.Coordinates.Z, coords2.Coordinates.Z);
            return vector;
        }

        private Vector3 getMinimumCoordinateByCorner(string cornerName)
        {
            Vector3 vector = new Vector3();
            Vertice coords1 = _verticesCube1.Where(x => x.VerticeName.Equals(cornerName)).FirstOrDefault();
            Vertice coords2 = _verticesCube2.Where(x => x.VerticeName.Equals(cornerName)).FirstOrDefault();

            vector.X = MathF.Min(coords1.Coordinates.X, coords2.Coordinates.X);
            vector.Y = MathF.Min(coords1.Coordinates.Y, coords2.Coordinates.Y);
            vector.Z = MathF.Min(coords1.Coordinates.Z, coords2.Coordinates.Z);
            return vector;
        }
    }
}
