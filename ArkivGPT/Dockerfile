FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ArkivGPT/ArkivGPT.csproj", "ArkivGPT/"]
RUN dotnet restore "ArkivGPT/ArkivGPT.csproj"
COPY . .
WORKDIR "/src/ArkivGPT"
RUN dotnet build "ArkivGPT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArkivGPT.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArkivGPT.dll"]
