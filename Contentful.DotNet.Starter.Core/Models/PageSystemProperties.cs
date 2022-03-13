using System;
using System.Diagnostics.CodeAnalysis;

namespace Contentful.DotNet.Starter.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class PageSystemProperties
    {
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
