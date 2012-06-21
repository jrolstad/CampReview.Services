using System;
using System.Linq;
using CampReview.Core.Commands;
using CampReview.Core.Models;
using CampReview.Data;
using FizzWare.NBuilder;
using NUnit.Framework;
using Rhino.Mocks;

namespace CampReview.Core.Test.Commands
{
    [TestFixture]
    public class When_getting_a_region
    {
        [Test]
        public void Then_all_regions_are_obtained()
        {
            // Arrange
            var regionId = Guid.NewGuid().ToString();

            var region = Builder<Region>.CreateNew().Build();
            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Get<Region>(regionId)).Return(region);
        
            var command = new GetRegionCommand(repository);

            // Act
            var result = command.Execute(regionId);

            // Assert
            Assert.That(result,Is.EqualTo(region));
        }
    }
}