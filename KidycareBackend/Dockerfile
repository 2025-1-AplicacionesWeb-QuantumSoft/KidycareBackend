FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY . .

RUN dotnet restore "KidycareBackend/KidycareBackend.csproj"

WORKDIR /src/KidycareBackend

RUN dotnet build "KidycareBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build


