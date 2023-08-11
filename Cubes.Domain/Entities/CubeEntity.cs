using System.Numerics;

namespace Cubes.Domain.Entities
{
    public class CubeEntity
    {
        public string CubeName { get; set; }
        public Dictionary<string, List<Vertice>> Vertices;

        public class Vertice
        {
            public string VerticeName { get; set; }
            public Vector3 Coordinates { get; set; }
        }
    }
}
