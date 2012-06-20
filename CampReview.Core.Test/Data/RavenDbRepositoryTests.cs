using System;
using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Data;
using CampReview.Core.Models;
using Directus.Extensions.Core;
using FizzWare.NBuilder;
using NUnit.Framework;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace CampReview.Core.Test.Data
{
    [TestFixture]
    public class RavenDbRepositoryTests
    {
        private RavenDbRepository _repository;
        private DocumentStore _documentStore;

        [SetUp]
        public void BeforeEach()
        {
            _documentStore = new EmbeddableDocumentStore {RunInMemory = true};
            _documentStore.Initialize();

            _repository = new RavenDbRepository(_documentStore);

        }

        [Test]
        public void When_saving_then_the_item_is_saved()
        {
            // Arrange
            var region = Builder<Region>.CreateNew().Build();

            // Act
            _repository.Save(region);

            // Assert
            var regionInStore = _documentStore.OpenSession().Load<Region>(region.Id);

            Assert.That(regionInStore.Name,Is.EqualTo(region.Name));
        }

        [Test]
        public void When_getting_an_existing_item_then_it_is_obtained()
        {
            // Arrange
            var region = Builder<Region>.CreateNew().Build();
            using(var session = _documentStore.OpenSession())
            {
                session.Store(region);
                session.SaveChanges();
            }
            
            // Act
            var result = _repository.Get<Region>(region.Id);

            // Assert
            Assert.That(result.Name,Is.EqualTo(region.Name));
        }

        [Test]
        public void When_querying_then_matching_items_are_obtained()
        {
            // Arrange
            var regions = Builder<Region>.CreateListOfSize(3).Build();
            using (var session = _documentStore.OpenSession())
            {
                regions.Each(r => session.Store(r));
                session.SaveChanges();
            }

            // Act
            var lastRegionName = regions.Last().Name;
            var result = _repository
                .Find<Region>()
                .Where(r => r.Name == lastRegionName)
                .ToList();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void When_getting_a_non_existing_item_then_null_is_obtained()
        {
            // Arrange
          
            // Act
            var result = _repository.Get<Region>(Guid.NewGuid().ToString());

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void When_deleting_an_existing_item_then_it_is_deleted()
        {
            // Arrange
            var region = Builder<Region>.CreateNew().Build();
           _repository.Save(region);

            // Act
            _repository.Delete(region);

            // Assert
            var regionInStore = _documentStore.OpenSession().Load<Region>(region.Id);

            Assert.That(regionInStore, Is.Null);
        }
    }
}