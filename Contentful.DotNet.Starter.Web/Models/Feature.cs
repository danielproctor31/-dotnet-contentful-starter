using Contentful.Core.Models;
using Contentful.DotNet.Starter.Core.Models;

namespace Contentful.DotNet.Starter.Web.Models
{
    public class Feature : IEntity
    {
        public ComponentSystemProperties Sys { get; set; }
        public string Title { get; set; }
        public Document Text { get; set; }
        public Asset Image { get; set; }
    }
}
