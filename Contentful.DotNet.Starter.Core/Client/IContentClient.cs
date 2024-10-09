using Contentful.DotNet.Starter.Core.Models;

namespace Contentful.DotNet.Starter.Core.Client;

public interface IContentClient
{
    Task<List<T>?> GetEntries<T>(string contentType, string field, string value) where T : IEntity;
}