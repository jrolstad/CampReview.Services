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
    public class When_getting_all_regions
    {
        [Test]
        public void Then_all_regions_are_obtained()
        {
            // Arrange
            var regions = Builder<Region>.CreateListOfSize(10).Build().AsQueryable();
            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Find<Region>()).Return(regions);
        
            var command = new GetRegionsCommand(repository);

            // Act
            var result = command.Execute(Defaults.DefaultRequest);

            // Assert
            Assert.That(result,Is.EquivalentTo(regions));
        }
    }
}