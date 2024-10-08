using Contentful.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Contentful.DotNet.Starter.Core.Client;

namespace Contentful.DotNet.Starter.Core;

[ExcludeFromCodeCoverage]
public static class ServiceConfiguration
{

    public static void AddContentfulServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddContentful(configuration);
        services.AddTransient<IContentClient, ContentClient>();
    }
}
