using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models;
using CampReview.Api.Models.Requests;
using CampReview.Core.Conversions;
using CampReview.Core.Models;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;

namespace CampReview.Api.Test.Conversions
{
    [TestFixture]
    public class When_mapping_from_create_campground_request
    {
        private CreateCampgroundRequest _source;
        private Core.Commands.Requests.CreateCampgroundRequest _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var kernel = new StandardKernel();
            IoC.Configure(kernel);

            _source = Builder<CreateCampgroundRequest>
                .CreateNew()
                .Do(r=>r.Location = new []{1.2m,3.4m})
                .Build();
            var mapper = kernel.Get<IMapper<CreateCampgroundRequest, Core.Commands.Requests.CreateCampgroundRequest>>();

            _result = mapper.Map(_source);
        }

        [Test]
        public void Then_the_id_is_mapped()
        {
            // Assert
            Assert.That(_result.RegionId,Is.EqualTo(_source.RegionId));
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