var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Contentful_DotNet_Starter_Web>("apiservice");

builder.Build().Run();
