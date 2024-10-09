using Aspire.ServiceDefaults;
using Contentful.Core.Configuration;
using Contentful.DotNet.Starter.Core;
using Contentful.DotNet.Starter.Web;

var builder = WebApplication.CreateBuilder(args);

// aspire
builder.AddServiceDefaults();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.Configure<AppSettings>(builder.Configuration.Bind);

// contentful
builder.Services.AddSingleton<IContentTypeResolver, EntityResolver>();
builder.Services.AddContentfulServices(builder.Configuration);

// swagger
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
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// aspire
app.MapDefaultEndpoints();

app.Run();
