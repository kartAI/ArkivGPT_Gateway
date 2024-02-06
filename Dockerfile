﻿# Use the Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /gateway

# Copy csproj and restore any dependencies (via NuGet)
COPY ["ArkivGPT/ArkivGPT.csproj", "ArkivGPT/"]
RUN dotnet restore "ArkivGPT/ArkivGPT.csproj"

# Copy the project files and build our release
COPY . .
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS dev-env
WORKDIR /gateway
COPY --from=build-env /gateway/out .

# Run the gRPC client
ENTRYPOINT ["dotnet", "ArkivGPT.dll"]