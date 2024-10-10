# contentful-dotnet-starter

## Overview
Provides a wrapper around the Dotnet Contentful SDK to get pages and content in a known, easy to use page format.

## Setup
To use this client, your project will need to reference `Contentful.DotNet.Starter.Core` and should have the following [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows):
```
ContentfulOptions:SpaceId
ContentfulOptions:DeliveryApiKey
ContentfulOptions:PreviewApiKey # optional
ContentfulOptions:ManagementApiKey # optional
```

The project will also need to call `AddContentfulServices` on startup.
```C#
serviceConfiguration.AddContentfulServices(configuration);
```

`Contentful.DotNet.Starter.Web` is provided as an example starter project.

### Content Types
Use the contentful cli app to generate the models from your existing content model: https://github.com/contentful/dotnet-models-creator-cli

In this example we have a page type with a list of content references.

```C#
public class Page : IPage
{
    public List<IEntity> Content { get; set; }
}
```
And a Feature Component:
```C#
public class FeatureComponent : IComponent
{
    public string Title { get; set; }
}
```

Any registered type should be implementing `IPage` (for pages) and `IComponent` for components. These then be registered in the resolver, with the key representing the contentTypeId in Contentful.

```C#
public class EntityResolver : IContentTypeResolver
{
    private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>()
    {
        {"page", typeof(Page)},
        { "feature", typeof(FeatureComponent) }
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
