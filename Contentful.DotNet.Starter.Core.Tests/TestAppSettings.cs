using Microsoft.Extensions.Options;

namespace Contentful.DotNet.Starter.Core.Tests
{
    public static class TestAppSettings
    {
        public static IOptions<AppSettings> Options => Microsoft.Extensions.Options.Options.Create(Value);

        public static AppSettings Value => new AppSettings
        {

        };
    }
}
