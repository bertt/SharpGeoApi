FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "SharpGeoApi.Services/SharpGeoApi.Services.csproj"
WORKDIR "/src/SharpGeoApi.Services"
RUN dotnet build "SharpGeoApi.Services.csproj" -c Release  -r linux-musl-x64 -o /app/build

FROM build AS publish
RUN dotnet publish "SharpGeoApi.Services.csproj" -c Release -r linux-musl-x64  /p:PublishSingleFile=true -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/SharpGeoApi.Services/sample_config.yml .
COPY --from=build /src/SharpGeoApi.Services/testdata ./testdata

ENV ASPNETCORE_URLS http://*:$PORT
ENTRYPOINT ["/app/SharpGeoApi.Services"]