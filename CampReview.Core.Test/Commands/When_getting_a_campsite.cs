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
    public class When_getting_a_campsite
    {
        [Test]
        public void Then_the_campsite_is_obtained()
        {
            // Arrange
            var campsiteId = Guid.NewGuid().ToString();

            var campsite = Builder<Campsite>.CreateNew().Build();
            var repository = MockRepository.GenerateStub<IRepository>();
            repository.Stub(r => r.Get<Campsite>(campsiteId)).Return(campsite);
        
            var command = new GetCampsiteCommand(repository);

            // Act
            var result = command.Execute(campsiteId);

            // Assert
            Assert.That(result,Is.EqualTo(campsite));
        }
    }
}