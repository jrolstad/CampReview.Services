using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models.Requests;
using CampReview.Core.Conversions;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;

namespace CampReview.Api.Test.Conversions
{
    [TestFixture]
    public class When_mapping_from_create_campsite_request
    {
        private CreateCampsiteRequest _source;
        private Core.Commands.Requests.CreateCampsiteRequest _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var kernel = new StandardKernel();
            IoC.Configure(kernel);

            _source = Builder<CreateCampsiteRequest>
                .CreateNew()
                .Do(r=>r.Location = new []{1.2m,3.4m})
                .Build();
            var mapper = kernel.Get<IMapper<CreateCampsiteRequest, Core.Commands.Requests.CreateCampsiteRequest>>();

            _result = mapper.Map(_source);
        }

        [Test]
        public void Then_the_id_is_mapped()
        {
            // Assert
            Assert.That(_result.CampgroundId,Is.EqualTo(_source.CampgroundId));
        }

        [Test]
        public void Then_the_name_is_mapped()
        {
            // Assert
            Assert.That(_result.Name, Is.EqualTo(_source.Name));
        }

        [Test]
        public void Then_the_location_is_mapped()
        {
            // Assert
            Assert.That(_result.Location, Is.EqualTo(_source.Location));
        }
         

    }
}