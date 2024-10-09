using System.Diagnostics.CodeAnalysis;
using Contentful.DotNet.Starter.Core.Models;

namespace Content.DotNet.Starter.DomainModels;

[ExcludeFromCodeCoverage]
public class Page : IPage
{
    public PageSystemProperties Sys { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public List<IEntity> Content { get; set; }
}
