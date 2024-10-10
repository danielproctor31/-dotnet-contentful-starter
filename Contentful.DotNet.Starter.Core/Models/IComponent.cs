namespace Contentful.DotNet.Starter.Core.Models;

public interface IComponent : IEntity
{
    public ComponentSystemProperties? Sys { get; set; }
}
