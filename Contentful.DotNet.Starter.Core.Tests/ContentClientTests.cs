using System.Collections.Generic;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Contentful.DotNet.Starter.Core.Client;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Contentful.DotNet.Starter.Core.Tests;

public class ContentClientTests
{
    private Mock<IContentfulClient> _contentfulClient;

    private ContentClient _contentClient;

    [SetUp]
    public void Setup()
    {
        _contentfulClient = new Mock<IContentfulClient>();
        
        var optionsMonitorMock = new Mock<IOptionsMonitor<AppSettings>>();

        var appSettings = new Mock<AppSettings>();
        appSettings.Setup(x => x.ContentfulOptions).Returns(new ContentfulOptions { IncludeLevel = 10 });
        optionsMonitorMock.Setup(x => x.CurrentValue).Returns(appSettings.Object);

        _contentClient = new ContentClient(new TestEntityResolver(), _contentfulClient.Object,
            optionsMonitorMock.Object);
    }

    [Test]
    public async Task GetEntries()
    {
        var items = new List<TestPage>();

        _contentfulClient.Setup(x => x.GetEntries(It.IsAny<QueryBuilder<TestPage>>(), default))
            .ReturnsAsync(new ContentfulCollection<TestPage> { Items = items });

        var result = await _contentClient.GetEntries<TestPage>("", "", "");

        Assert.That(items, Is.EqualTo(result));

        _contentfulClient.Verify(x => x.GetEntries(It.IsAny<QueryBuilder<TestPage>>(), default));
    }
}