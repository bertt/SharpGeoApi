FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SharpGeoApi/SharpGeoApi.Services.csproj", "SharpGeoApi/"]
COPY ["SharpGeoApi.Core/SharpGeoApi.Core.csproj", "SharpGeoApi.Core/"]
RUN dotnet restore "SharpGeoApi/SharpGeoApi.Services.csproj"
COPY . .
WORKDIR "/src/SharpGeoApi"
RUN dotnet build "SharpGeoApi.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharpGeoApi.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharpGeoApi.Services.dll"]