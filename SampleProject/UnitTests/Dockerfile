FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test-runner
WORKDIR /app

# restore
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY UnitTests/ ./UnitTests/
RUN dotnet restore ./UnitTests/UnitTests.csproj

# Run the unit tests
RUN dotnet build  UnitTests/UnitTests.csproj -c Debug --no-restore
ENTRYPOINT ["dotnet", "test", "UnitTests/UnitTests.csproj", "--no-restore"]