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
    public class When_getting_all_campsites_in_a_campground
    {
        [Test]
        public void Then_all_campsites_in_that_campground_are_obtained()
        {
            // Arrange
            var campgroundId = "somewhere";

            var campsites = Builder<Campsite>
                .CreateListOfSize(10)
                .All()
                .Do(c=>c.CampgroundId = campgroundId)
                .Build()
                .AsQueryable();

            campsites.Last().CampgroundId = "not here";

            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Find<Campsite>()).Return(campsites);
        
            var command = new GetCampsitesInCampgroundCommand(repository);

            // Act
            var result = command.Execute(campgroundId);

            // Assert
            Assert.That(result.Select(r=>r.CampgroundId).Distinct().ToArray(),Is.EquivalentTo(new[]{campgroundId}));
        }
    }
}