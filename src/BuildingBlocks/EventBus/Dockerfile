FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app

COPY . .

WORKDIR /app/src/BuildingBlocks/EventBus
RUN dotnet restore EventBus.csproj
