using System;
using System.Collections.Generic;
using System.Linq;
using CampReview.Api.Controllers;
using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using FizzWare.NBuilder;
using NUnit.Framework;
using Ninject;
using Rhino.Mocks;

namespace CampReview.Api.Test.Controllers
{
    [TestFixture]
    public class RegionsControllerTests
    {
        private StandardKernel _kernel;

        [SetUp]
        public void BeforeEach()
        {
            _kernel = new StandardKernel();
            IoC.Configure(_kernel);
        }

        [Test]
        public void When_obtaining_all_regions_then_all_are_obtained()
        {
            // Arrange
            var regions = Builder<Region>.CreateListOfSize(3).Build();
            var command = MockRepository.GenerateStub<ICommand<Request,IEnumerable<Region>>>();
            command.Stub(c => c.Execute(Arg<Request>.Is.Anything)).Return(regions);
            _kernel.Rebind<ICommand<Request, IEnumerable<Region>>>().ToConstant(command);

            var controller = _kernel.Get<RegionsController>();

            // Act
            var result = controller.Get();

            // Assert
            Assert.That(result.Count(),Is.EqualTo(regions.Count));
        } 

    }
}