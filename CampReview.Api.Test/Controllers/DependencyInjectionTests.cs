using System;
using CampReview.Api.Controllers;
using CampReview.Api.Infrastructure.DependencyInjection;
using NUnit.Framework;
using Ninject;

namespace CampReview.Api.Test.Controllers
{
    [TestFixture]
    public class DependencyInjectionTests
    {
        [TestFixtureSetUp]
        public void BeforeAll()
        {
            IoC.Configure(new StandardKernel());
        }
        [Test]
        [TestCase(typeof(RegionsController))]
        [TestCase(typeof(CampgroundsController))]
        [TestCase(typeof(CampsitesController))]
        public void When_getting_a_controller_then_it_can_be_obtained(Type controllerType)
        {
            // Act
            var result = IoC.Get(controllerType);

            // Assert
            Assert.That(result,Is.Not.Null);
        }
         

    }
}