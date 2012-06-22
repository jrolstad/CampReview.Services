using System;
using CampReview.Core.Commands;
using CampReview.Core.Models;
using CampReview.Data;
using FizzWare.NBuilder;
using NUnit.Framework;
using Rhino.Mocks;

namespace CampReview.Core.Test.Commands
{
    [TestFixture]
    public class When_getting_a_campground
    {
        [Test]
        public void Then_all_regions_are_obtained()
        {
            // Arrange
            var campgroundId = Guid.NewGuid().ToString();

            var campground = Builder<Campground>.CreateNew().Build();
            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Get<Campground>(campgroundId)).Return(campground);
        
            var command = new GetCampgroundCommand(repository);

            // Act
            var result = command.Execute(campgroundId);

            // Assert
            Assert.That(result,Is.EqualTo(campground));
        }
    }
}