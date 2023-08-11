using Cubes.Application.Interfaces;
using Cubes.Application.Services;
using Cubes.Domain.Entities;
using Cubes.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cubes.Application.Tests
{
    //public class DependencySetupFixture
    //{
    //    public DependencySetupFixture()
    //    {
    //        var serviceCollection = new ServiceCollection();
    //        serviceCollection.AddTransient<IBuildCubesList, BuildCubesList>();
    //        //serviceCollection.AddTransient<IDepartmentAppService, DepartmentAppService>();

    //        ServiceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    public ServiceProvider ServiceProvider { get; private set; }
    //}



    public class BuildCubesListTests : BaseTestsFixtures
    {
        public BuildCubesListTests(DependencySetupFixture fixture) : base(fixture)
        {
        }

        //private ServiceProvider _serviceProvider;

        //public BuildCubesListTests(DependencySetupFixture fixture)
        //{
        //    _serviceProvider = fixture.ServiceProvider;
        //}


        [Fact]
        public void BuildCubesList_ShouldBuildACubesList()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //Arrange            
                string[] dataCubes = { "5,5,5,5", "6,6,6,5" };
                var _buildCubesList = scope.ServiceProvider.GetServices<IBuildCubesList>().FirstOrDefault();

                // Act
                List<CubeEntity> cubeEntities = _buildCubesList.buildCubeEntitiesList(dataCubes).Result;

                //Assert
                Assert.NotEmpty(cubeEntities);
                Assert.Equal(2, cubeEntities.Count);
            }
        }
    }
}
