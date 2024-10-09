namespace Contentful.DotNet.Starter.Core.Models;

public interface IPage : IEntity
{
    public static string ContentType => "page";
    public PageSystemProperties Sys { get; set; }
}
