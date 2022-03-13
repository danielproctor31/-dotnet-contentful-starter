using Contentful.DotNet.Starter.Core.Models;
using System.Collections.Generic;

namespace Contentful.DotNet.Starter.Core.Tests
{
    public class TestPage : IEntity
    {
        public List<IEntity> Content { get; set; }

        public PageSystemProperties Sys { get; set; }
    }
}