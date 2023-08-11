using Cubes.Application.Interfaces;
using Cubes.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Formats.Asn1.AsnWriter;

namespace Cubes.Application.Tests
{
    public class ValidationServiceTests : BaseTestsFixtures
    {
        public ValidationServiceTests(DependencySetupFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void AreInputDataValid_ShouldReturnTrue()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //Arrange
                string[] dataCubes = { "5,5,5,5", "6,6,6,5" };
                var _validationService = scope.ServiceProvider.GetServices<IValidationService>().FirstOrDefault();

                // Act
                bool result = _validationService.AreInputDataValid(dataCubes);

                //Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void AreInputDataValid_BadFormat_ShouldReturnFalse()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //Arrange
                string[] dataCubes = { "5,5,A,5", "6,6,6,5" };
                var _validationService = scope.ServiceProvider.GetServices<IValidationService>().FirstOrDefault();

                // Act
                bool result = _validationService.AreInputDataValid(dataCubes);

                //Assert
                Assert.False(result);
            }
        }

        [Fact]
        public void AreInputDataValid_Empty_ShouldReturnFalse()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //Arrange
                string[] dataCubes = { "5,5,5,5", "" };
                var _validationService = scope.ServiceProvider.GetServices<IValidationService>().FirstOrDefault();

                // Act
                bool result = _validationService.AreInputDataValid(dataCubes);

                //Assert
                Assert.False(result);
            }
        }
    }
}
