using Contentful.Core.Configuration;
using Contentful.DotNet.Starter;
using Contentful.DotNet.Starter.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.Configure<AppSettings>(builder.Configuration.Bind);

builder.Services.AddSingleton<IContentTypeResolver, EntityResolver>();
builder.Services.AddContentfulServices(builder.Configuration);

IWebHostEnvironment env = app.Environment;
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});