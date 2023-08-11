using Cubes.Application.Interfaces;
using Cubes.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cubes.Application.Tests
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IBuildCubesList, BuildCubesList>();
            serviceCollection.AddTransient<IValidationService, ValidationService>();
            serviceCollection.AddTransient<ICalculateIntersectingVolume, CalculateIntersectingVolume>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

    public class BaseTestsFixtures : IClassFixture<DependencySetupFixture>
    {
        protected ServiceProvider _serviceProvider;

        public BaseTestsFixtures(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
    }
}
