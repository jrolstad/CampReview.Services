using CampReview.Core.Commands;
using CampReview.Core.Models;
using CampReview.Data;
using FizzWare.NBuilder;
using NUnit.Framework;
using Rhino.Mocks;

namespace CampReview.Core.Test.Commands
{
    [TestFixture]
    public class When_saving_a_campground
    {
        [Test]
        public void Then_the_campground_is_saved()
        {
            // Arrange
            var repository = MockRepository.GenerateStub<IRepository>();

            var campground = Builder<Campground>.CreateNew().Build();

            var command = new SaveCampgroundCommand(repository);

            // Act
            command.Execute(campground);

            // Assert
            repository.AssertWasCalled(r=>r.Save(campground));
        }
        
    }
}