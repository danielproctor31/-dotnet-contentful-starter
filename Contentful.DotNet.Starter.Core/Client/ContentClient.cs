using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Search;
using Contentful.DotNet.Starter.Core.Models;
using Microsoft.Extensions.Options;

namespace Contentful.DotNet.Starter.Core.Client
{
    public class ContentClient : IContentClient
    {
        private readonly IContentfulClient _contentfulClient;
        private readonly AppSettings _appSettings;

        public ContentClient(IContentTypeResolver contentTypeResolver,
            IContentfulClient contentfulClient, IOptions<AppSettings> appSettings)
        {
            _contentfulClient = contentfulClient;

            _appSettings = appSettings.Value;
            _contentfulClient.ContentTypeResolver = contentTypeResolver;
        }
        
        public async Task<List<T>> GetEntries<T>(string contentType, string field, string value) where T : IEntity
        {
            var queryBuilder = QueryBuilder<T>.New.ContentTypeIs(contentType).FieldEquals(field, value)
                .Include(_appSettings.ContentfulOptions.IncludeLevel);

            var items = await _contentfulClient.GetEntries(queryBuilder);

            return items?.Items?.ToList();
        }
    }
}