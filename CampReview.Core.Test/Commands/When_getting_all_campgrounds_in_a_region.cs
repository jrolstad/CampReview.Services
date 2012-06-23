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
    public class When_getting_all_campgrounds_in_a_region
    {
        [Test]
        public void Then_all_campgrounds_in_that_region_are_obtained()
        {
            // Arrange
            var regionID = "somewhere";

            var campgrounds = Builder<Campground>
                .CreateListOfSize(10)
                .All()
                .Do(c=>c.RegionId = regionID)
                .Build()
                .AsQueryable();

            campgrounds.Last().RegionId = "not here";

            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Find<Campground>()).Return(campgrounds);
        
            var command = new GetCampgroundsInRegionCommand(repository);

            // Act
            var result = command.Execute(regionID);

            // Assert
            Assert.That(result.Select(r=>r.RegionId).Distinct().ToArray(),Is.EquivalentTo(new[]{regionID}));
        }
    }
}