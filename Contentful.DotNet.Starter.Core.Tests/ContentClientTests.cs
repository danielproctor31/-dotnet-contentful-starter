using System.Collections.Generic;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Contentful.DotNet.Starter.Core.Client;
using Moq;
using NUnit.Framework;

namespace Contentful.DotNet.Starter.Core.Tests
{
    public class ContentClientTests
    {
        private Mock<IContentfulClient> _contentfulClient;

        private ContentClient _contentClient;

        [SetUp]
        public void Setup()
        {
            _contentfulClient = new Mock<IContentfulClient>();

            _contentClient = new ContentClient(new TestEntityResolver(), _contentfulClient.Object,
                TestAppSettings.Options);
        }

        [Test]
        public async Task GetEntries()
        {
            var items = new List<TestPage>();

            _contentfulClient.Setup(x => x.GetEntries(It.IsAny<QueryBuilder<TestPage>>(), default))
                .ReturnsAsync(new ContentfulCollection<TestPage> { Items = items });

            var result = await _contentClient.GetEntries<TestPage>("", "", "");

            Assert.AreEqual(items, result);

            _contentfulClient.Verify(x => x.GetEntries(It.IsAny<QueryBuilder<TestPage>>(), default));
        }
    }
}