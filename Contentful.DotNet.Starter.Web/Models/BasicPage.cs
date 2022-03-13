using System.Collections.Generic;
using Contentful.DotNet.Starter.Core.Models;

namespace Contentful.DotNet.Starter.Web.Models
{
    public class BasicPage : IEntity
    {
        public PageSystemProperties Sys { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public List<IEntity> Content { get; set; }
    }
}
