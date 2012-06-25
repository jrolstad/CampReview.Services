using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models.Requests;
using CampReview.Core.Conversions;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;

namespace CampReview.Api.Test.Conversions
{
    [TestFixture]
    public class When_mapping_from_create_campsite_review_request
    {
        private CreateCampsiteReviewRequest _source;
        private Core.Commands.Requests.CreateCampsiteReviewRequest _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var kernel = new StandardKernel();
            IoC.Configure(kernel);

            _source = Builder<CreateCampsiteReviewRequest>
                .CreateNew()
                .Build();
            var mapper = kernel.Get<IMapper<CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest>>();

            _result = mapper.Map(_source);
        }

        [Test]
        public void Then_the_id_is_mapped()
        {
            // Assert
            Assert.That(_result.CampsiteId,Is.EqualTo(_source.CampsiteId));
        }

        [Test]
        public void Then_the_rating_is_mapped()
        {
            // Assert
            Assert.That(_result.Rating, Is.EqualTo(_source.Rating));
        }
    }
}