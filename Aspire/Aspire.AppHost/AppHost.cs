var builder = DistributedApplication.CreateBuilder(args);

var weatherService = builder.AddProject<Projects.Api>("weatherservice");

var gateway = builder.AddProject<Projects.GatewayApi>("gateway").WaitFor(weatherService);

builder.Build().Run();
