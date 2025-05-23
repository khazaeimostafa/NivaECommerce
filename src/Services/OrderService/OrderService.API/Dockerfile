FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build

WORKDIR /app

# 1. کپی تمام فایل‌های csproj کل پروژه‌ها (API و دپندنسی‌ها)
COPY src/Services/OrderService/OrderService.API/*.csproj ./src/Services/OrderService/OrderService.API/
COPY src/Services/OrderService/OrderService.Application/*.csproj ./src/Services/OrderService/OrderService.Application/
COPY src/Services/OrderService/OrderService.Infrastructure/*.csproj ./src/Services/OrderService/OrderService.Infrastructure/
COPY src/BuildingBlocks/EventBus/*.csproj ./src/BuildingBlocks/EventBus/

# 2. restore کردن با مسیر پروژه API
RUN dotnet restore src/Services/OrderService/OrderService.API/OrderService.API.csproj

# 3. کپی کل سورس کد پروژه
COPY . .

# 4. پابلیش پروژه API
RUN dotnet publish src/Services/OrderService/OrderService.API/OrderService.API.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "OrderService.API.dll"]
