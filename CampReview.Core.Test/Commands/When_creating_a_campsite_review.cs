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
    public class When_creating_a_campsite_review
    {
        private IRepository _repository;
        private CreateCampsiteReviewRequest _request;
        private Campsite _response;
        private Campsite _campsite;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var campsiteId = "the site number";
            _campsite = Builder<Campsite>.CreateNew().Do(c => c.Id = campsiteId).Build();

            _repository = MockRepository.GenerateStub<IRepository>();
            _repository.Stub(r => r.Get<Campsite>(campsiteId)).Return(_campsite);
           
            var command = new CreateCampsiteReviewCommand(_repository);

            _request = Builder<CreateCampsiteReviewRequest>
                .CreateNew()
                .Do(r=>r.CampsiteId = campsiteId)
                .Do(r=>r.Rating = 4)
                .Build();

            _response = command.Execute(_request);
        }

        [Test]
        public void Then_the_review_is_created_with_the_rating()
        {
            // Assert
            Assert.That(_campsite.Review.Rating, Is.EqualTo(_request.Rating));
            Assert.That(_response.Review.Rating, Is.EqualTo(_request.Rating));
        }

        [Test]
        public void Then_the_campsite_is_saved()
        {
            // Assert
            _repository.AssertWasCalled(r=>r.Save(_campsite));
        }

    }
}