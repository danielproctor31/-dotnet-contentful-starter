namespace Contentful.DotNet.Starter.Core.Models;

public interface IPage : IEntity
{
    public PageSystemProperties? Sys { get; set; }
    public string Slug { get; set; }

}
