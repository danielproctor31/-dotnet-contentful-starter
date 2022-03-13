using System.Diagnostics.CodeAnalysis;

namespace Contentful.DotNet.Starter.Core
{
    [ExcludeFromCodeCoverage]
    public class AppSettings
    {
        public ContentfulOptions ContentfulOptions { get; set; }
    }

    public class ContentfulOptions
    {
        public int IncludeLevel { get; set; }
    }
}
