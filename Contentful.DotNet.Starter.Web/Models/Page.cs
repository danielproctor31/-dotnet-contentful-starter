using System.Diagnostics.CodeAnalysis;
using Contentful.DotNet.Starter.Core.Models;

namespace Contentful.DotNet.Starter.Web.Models;

[ExcludeFromCodeCoverage]
public class Page : IEntity
{
    public PageSystemProperties Sys { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public List<IEntity> Content { get; set; }
}
