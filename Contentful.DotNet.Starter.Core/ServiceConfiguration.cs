using Contentful.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.DotNet.Starter.Core.Client;
using Microsoft.Extensions.Options;

namespace Contentful.DotNet.Starter.Core
{
    [ExcludeFromCodeCoverage]
    public static class ServiceConfiguration
    {

        public static void AddContentfulServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddContentful(configuration);

            var builder = services.BuildServiceProvider();

            services.AddTransient<IContentClient>(x => new ContentClient(builder.GetRequiredService<IContentTypeResolver>(),
                builder.GetRequiredService<IContentfulClient>(), builder.GetRequiredService<IOptions<AppSettings>>()));
        }
    }
}
