using Cubes.Application.Interfaces;
using Cubes.Application.Services;
using Cubes.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Cubes.Domain.Entities.CubeEntity;

namespace Cubes.Application.Tests
{
    public class CalculateIntersectingVolumeTests : BaseTestsFixtures
    {
        public CalculateIntersectingVolumeTests(DependencySetupFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void CalculateIntersectingCubesVolume_ShouldCalculateVolume()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //Arrange
                List<Vertice> verticesCube1, verticesCube2;
                string[] dataCubes = { "5,5,5,5", "6,6,6,5" };
                var _buildCubesList = scope.ServiceProvider.GetServices<IBuildCubesList>().FirstOrDefault();
                                
                List<CubeEntity> cubeEntities = _buildCubesList.buildCubeEntitiesList(dataCubes).Result;
                CubeEntity cube1 = cubeEntities.Where(x => x.CubeName.Equals("cube1")).FirstOrDefault();
                CubeEntity cube2 = cubeEntities.Where(x => x.CubeName.Equals("cube2")).FirstOrDefault();

                cube1.Vertices.TryGetValue("cube1", out verticesCube1);
                cube2.Vertices.TryGetValue("cube2", out verticesCube2);

                var _calculateIntersectingVolume = scope.ServiceProvider.GetServices<ICalculateIntersectingVolume>().FirstOrDefault();

                // Act
                var result = _calculateIntersectingVolume.CalculateIntersectingCubesVolume(verticesCube1, verticesCube2).Result;

                //Assert
                Assert.Equal(48, result);
            }
        }
    }
}
