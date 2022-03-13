# contentful-dotnet-starter

## Overview
Provides a wrapper around the Dotnet Contentful SDK to get pages and content in a known, easy to use page format.

## Setup
To use this client, your project will need to reference `Contentful.DotNet.Starter.Core` and should have the following appsettings, replacing any values where required:
```
  "ContentfulOptions": {
    "SpaceId": "",
    "ManagementApiKey": "",
    "Environment": "master",
    "DeliveryApiKey": ",
    "PreviewApiKey": "",
    "UsePreviewApi": false,
    "MaxNumberOfRateLimitRetries": 0,
    "IncludeLevel": 10
  }
```

The project will also need to call `AddContentfulServices` on startup.
```C#
ServiceConfiguration.AddContentfulServices(configuration);
```

`Contentful.DotNet.Starter.Web` is provided as an example starter project.

### Content Types
Use the contentful cli app to generate the models from your existing content model: https://github.com/contentful/dotnet-models-creator-cli

In this example we have a page type with a list of content references.

```C#
public class Page : IEntity
{
    public List<IEntity> Content { get; set; }
}
```

```C#
public class Feature : IEntity
{
    public string Title { get; set; }
}
```

Any registered type should be implemeting `IEntity`. These then be registered in an `IContentType` resolver class, with the key representing the contentTypeId in contentful.

```C#
public class EntityResolver : IContentTypeResolver
{
    private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>()
    {
        {"page", typeof(Page)},
        { "feature", typeof(Feature) }
    };

    public Type Resolve(string contentTypeId)
    {
        return _types.TryGetValue(contentTypeId, out var type) ? type : null;
    }
}
```
Registering the resolver in DI:
```C#
services.AddSingleton<IContentTypeResolver, EntityResolver>();
```
