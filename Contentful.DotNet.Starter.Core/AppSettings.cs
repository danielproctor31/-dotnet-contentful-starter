using System.Diagnostics.CodeAnalysis;

namespace Contentful.DotNet.Starter.Core;

[ExcludeFromCodeCoverage]
public class AppSettings
{
    public virtual ContentfulOptions ContentfulOptions { get; set; }
}

[ExcludeFromCodeCoverage]
public class ContentfulOptions
{
    public int IncludeLevel { get; set; }
}
