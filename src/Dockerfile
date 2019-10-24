FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "SharpGeoApi.Services/SharpGeoApi.Services.csproj"
WORKDIR "/src/SharpGeoApi.Services"
RUN dotnet build "SharpGeoApi.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharpGeoApi.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SharpGeoApi.Services.dll