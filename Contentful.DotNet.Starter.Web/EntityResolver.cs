using Content.DotNet.Starter.DomainModels;
using Content.DotNet.Starter.DomainModels.Fragments;
using Contentful.Core.Configuration;

namespace Contentful.DotNet.Starter.Web;

public class EntityResolver : IContentTypeResolver
{
    private readonly Dictionary<string, Type> _types = new()
    {
        { "page", typeof(Page) },
        { "feature", typeof(FeatureFragment) }
    };

    public Type? Resolve(string contentTypeId)
    {
        return _types.TryGetValue(contentTypeId, out var type) ? type : null;
    }
}
