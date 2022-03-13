using System.Linq;
using System.Threading.Tasks;
using Contentful.DotNet.Starter.Core.Client;
using Contentful.DotNet.Starter.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contentful.DotNet.Starter.Controllers
{
    [Controller]
    [Route("")]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> _logger;
        private readonly IContentClient _contentClient;

        public PageController(ILogger<PageController> logger, IContentClient contentClient)
        {
            _logger = logger;
            _contentClient = contentClient;
        }

        [HttpGet]
        [Route("{**path}")]
        public async Task<IEntity> Index(string path)
        {
            var items = await _contentClient.GetEntries<IEntity>("page", "fields.slug", path);

            if (items?.FirstOrDefault() == null)
                return null;

            var page = items.First();

            return page;
        }
    }
}
