FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# restore
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY UnitTests/UnitTests.csproj ./UnitTests/
RUN dotnet restore ./UnitTests/UnitTests.csproj

# publish
COPY UnitTests/ ./UnitTests/
RUN dotnet publish  UnitTests/UnitTests.csproj -c Debug --no-restore --no-self-contained

# Run the unit tests
RUN dotnet test UnitTests/UnitTests.csproj --no-restore