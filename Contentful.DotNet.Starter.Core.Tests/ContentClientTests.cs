using Bogus;
using Content.DotNet.Starter.DomainModels;
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
    private Mock<IContentfulClient>? _contentfulClient;

    private readonly Faker _faker = new();

    private ContentClient? _contentClient;

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
    public async Task GetEntries_GivenEntriesExist_ReturnsEntries()
    {
        var items = new List<Page>
        {
            new()
        };

        _contentfulClient!.Setup(x => x.GetEntries(It.IsAny<QueryBuilder<Page>>(), default))
            .ReturnsAsync(new ContentfulCollection<Page> { Items = items });

        var result = await _contentClient!.GetEntries<Page>(_faker.Lorem.Word(), _faker.Lorem.Word(), _faker.Lorem.Word());

        Assert.That(result, Is.EquivalentTo(items));

        _contentfulClient.Verify(x => x.GetEntries(It.IsAny<QueryBuilder<Page>>(), default));
    }
}
