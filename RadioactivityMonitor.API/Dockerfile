# Use the official .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy the project files and restore any dependencies
COPY ./RadioactivityMonitor.API/*.csproj ./RadioactivityMonitor.API/
COPY ./RadioactivityMonitor.Application/*.csproj ./RadioactivityMonitor.Application/
COPY ./RadioactivityMonitor.Domain/*.csproj ./RadioactivityMonitor.Domain/
COPY ./RadioactivityMonitor.Infrastructure/*.csproj ./RadioactivityMonitor.Infrastructure/
RUN dotnet restore ./RadioactivityMonitor.API/RadioactivityMonitor.API.csproj

# Copy the rest of the application files
COPY . ./

# Build the application
RUN dotnet publish ./RadioactivityMonitor.API/RadioactivityMonitor.API.csproj -c Release -o out

# Use the official ASP.NET Core runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Set the entry point for the application
ENTRYPOINT ["dotnet", "RadioactivityMonitor.API.dll"]