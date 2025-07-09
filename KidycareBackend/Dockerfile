
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

COPY ["KidycareBackend.csproj", "."]
RUN dotnet restore

COPY . ./


RUN dotnet publish "KidycareBackend.csproj" -c $BUILD_CONFIGURATION -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "KidycareBackend.dll"]
