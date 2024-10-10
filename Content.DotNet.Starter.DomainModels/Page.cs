using System.Diagnostics.CodeAnalysis;
using Contentful.DotNet.Starter.Core.Models;

namespace Content.DotNet.Starter.DomainModels;

[ExcludeFromCodeCoverage]
public class Page : IPage
{
    public string ContentType => "page";
    public PageSystemProperties? Sys { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public List<IEntity> Content { get; set; } = [];
}
