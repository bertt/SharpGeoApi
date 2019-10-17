FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SharpGeoApi/SharpGeoApi.csproj", "SharpGeoApi/"]
RUN dotnet restore "SharpGeoApi/SharpGeoApi.csproj"
COPY . .
WORKDIR "/src/SharpGeoApi"
RUN dotnet build "SharpGeoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharpGeoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharpGeoApi.dll"]