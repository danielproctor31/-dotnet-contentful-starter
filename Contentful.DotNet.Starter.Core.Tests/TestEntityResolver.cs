using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Contentful.Core.Configuration;

namespace Contentful.DotNet.Starter.Core.Tests;

[ExcludeFromCodeCoverage]
public class TestEntityResolver : IContentTypeResolver
{
    private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();

    public Type Resolve(string contentTypeId)
    {
        return _types.TryGetValue(contentTypeId, out var type) ? type : null;
    }
}