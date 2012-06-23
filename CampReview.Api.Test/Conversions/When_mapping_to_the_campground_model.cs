using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models;
using CampReview.Core.Conversions;
using CampReview.Core.Models;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;

namespace CampReview.Api.Test.Conversions
{
    [TestFixture]
    public class When_mapping_to_the_campground_model
    {
        private Campground _source;
        private CampgroundModel _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var kernel = new StandardKernel();
            IoC.Configure(kernel);

            _source = Builder<Campground>
                .CreateNew()
                .Do(c=>c.Location = Builder<Location>.CreateNew().Build())
                .Build();
            var mapper = kernel.Get<IMapper<Campground, CampgroundModel>>();

            _result = mapper.Map(_source);
        }

        [Test]
        public void Then_the_id_is_mapped()
        {
            // Assert
            Assert.That(_result.Id,Is.EqualTo(_source.Id));
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
            Assert.That(_result.Location,Is.EquivalentTo(new[]{_source.Location.Latitude,_source.Location.Longitude}));
        }

    }
}