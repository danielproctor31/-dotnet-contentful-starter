namespace Contentful.DotNet.Starter.Core.Models;

public interface IFragment : IEntity
{
    public ComponentSystemProperties? Sys { get; set; }
}
