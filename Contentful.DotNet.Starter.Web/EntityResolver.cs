using System;
using System.Collections.Generic;
using Contentful.Core.Configuration;
using Contentful.DotNet.Starter.Web.Models;

namespace Contentful.DotNet.Starter;

public class EntityResolver : IContentTypeResolver
{
    private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>()
    {
        { "page", typeof(Page) },
        { "feature", typeof(Feature) }
    };

    public Type Resolve(string contentTypeId)
    {
        return _types.TryGetValue(contentTypeId, out var type) ? type : null;
    }
}
