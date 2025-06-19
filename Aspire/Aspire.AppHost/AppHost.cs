var builder = DistributedApplication.CreateBuilder(args);

var weatherService = builder.AddProject<Projects.Api>("weatherservice");

var webUi = builder.AddNpmApp("angular", "../../SampleUi")
    .WaitFor(weatherService);

var gateway = builder.AddProject<Projects.GatewayApi>("gateway").WaitFor(webUi);

builder.Build().Run();
