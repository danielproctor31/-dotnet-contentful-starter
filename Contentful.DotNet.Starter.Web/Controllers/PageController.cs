using Content.DotNet.Starter.DomainModels;
using Contentful.DotNet.Starter.Core.Client;
using Contentful.DotNet.Starter.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contentful.DotNet.Starter.Web.Controllers;

[Controller]
[Route("")]
public class PageController(ILogger<PageController> logger, IContentClient contentClient) : ControllerBase
{
    [HttpGet]
    [Route("{**path}")]
    public async Task<IActionResult> Index(string path)
    {
        try
        {
            var items = await contentClient.GetEntries<IPage>("page",
                $"fields.{nameof(Page.Slug.ToLowerInvariant)}", path);

            if (items?.FirstOrDefault() == null)
                return NotFound();

            var page = items.First();

            return Ok(page);
        }
        catch(Exception e)
        {
            logger.LogError(e.Message);
            return BadRequest();
        }
    }
}
