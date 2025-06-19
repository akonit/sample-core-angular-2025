var builder = DistributedApplication.CreateBuilder(args);

var weatherService = builder.AddProject<Projects.Api>("weatherservice");

builder.Build().Run();
