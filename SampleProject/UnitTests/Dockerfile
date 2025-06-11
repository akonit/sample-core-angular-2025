FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test-runner
WORKDIR /app

# restore
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY UnitTests/UnitTests.csproj ./UnitTests/
RUN dotnet restore ./UnitTests/UnitTests.csproj

# publish
COPY UnitTests/ ./UnitTests/
RUN dotnet build  UnitTests/UnitTests.csproj -c Debug --no-restore

# Run the unit tests
ENTRYPOINT ["dotnet", "test", "UnitTests/UnitTests.csproj", "--no-restore", "--logger:trx;LogFileName=TestResults.trx", "--results-directory", "/app/TestResults"]