using Contentful.DotNet.Starter.Core.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Contentful.DotNet.Starter.Core.Tests;

[ExcludeFromCodeCoverage]
public class TestPage : IEntity
{
    public List<IEntity> Content { get; set; }

    public PageSystemProperties Sys { get; set; }
}