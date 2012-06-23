using System.Linq;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using CampReview.Data;
using FizzWare.NBuilder;
using NUnit.Framework;
using Rhino.Mocks;

namespace CampReview.Core.Test.Commands
{
    [TestFixture]
    public class When_creating_a_campsite
    {
        private IRepository _repository;
        private CreateCampsiteRequest _request;
        private Campsite _response;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            _repository = MockRepository.GenerateStub<IRepository>();
            _repository.Stub(r => r.Find<Campsite>()).Return(
                Builder<Campsite>
                    .CreateListOfSize(10)
                    .Build()
                    .AsQueryable());
            var command = new CreateCampsiteCommand(_repository);

            _request = Builder<CreateCampsiteRequest>
                .CreateNew()
                .Do(r=>r.Location = new []{45.5m,23.45m})
                .Do(r=>r.Name = "Where I camp at")
                .Build();

            _response = command.Execute(_request);
        }

        [Test]
        public void Then_the_campground_is_created_with_the_campground_id()
        {
            // Assert
            Assert.That(_response.CampgroundId,Is.EqualTo(_request.CampgroundId));
        }

        [Test]
        public void Then_the_campground_is_created_with_the_name()
        {
            // Assert
            Assert.That(_response.Name, Is.EqualTo(_request.Name));
        }

        [Test]
        public void Then_the_campground_is_created_with_the_location()
        {
            // Assert
            Assert.That(_response.Location.Latitude, Is.EqualTo(_request.Location[0]));
            Assert.That(_response.Location.Longitude, Is.EqualTo(_request.Location[1]));
        }

        [Test]
        public void Then_the_new_campground_is_saved()
        {
            // Assert
            _repository.AssertWasCalled(r=>r.Save(_response));
        }

    }
}