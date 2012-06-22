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
    public class When_mapping_from_the_region_model
    {
        private RegionModel _source;
        private Region _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var kernel = new StandardKernel();
            IoC.Configure(kernel);

            _source = Builder<RegionModel>.CreateNew().Build();
            var mapper = kernel.Get<IMapper<RegionModel, Region>>();

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
         

    }
}