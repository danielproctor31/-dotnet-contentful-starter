using Contentful.Core.Configuration;
using Contentful.DotNet.Starter.Core;
using Contentful.DotNet.Starter.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.Configure<AppSettings>(builder.Configuration.Bind);

builder.Services.AddSingleton<IContentTypeResolver, EntityResolver>();
builder.Services.AddContentfulServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();