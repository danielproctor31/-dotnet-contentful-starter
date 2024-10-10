using System.Diagnostics.CodeAnalysis;
using Contentful.Core.Models;
using Contentful.DotNet.Starter.Core.Models;

namespace Content.DotNet.Starter.DomainModels.Component;

[ExcludeFromCodeCoverage]
public class FeatureComponent : IComponent
{
    public string ContentType => "feature";
    public ComponentSystemProperties? Sys { get; set; }
    public string Title { get; set; } = string.Empty;
    public Document? Text { get; set; }
    public Asset? Image { get; set; }
}
