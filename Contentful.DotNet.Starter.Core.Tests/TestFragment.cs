using System.Diagnostics.CodeAnalysis;
using Contentful.DotNet.Starter.Core.Models;

namespace Contentful.DotNet.Starter.Core.Tests;

[ExcludeFromCodeCoverage]
public class TestComponent : IEntity
{
    public string Name { get; set; }
    public ComponentSystemProperties Sys { get; set; }
}