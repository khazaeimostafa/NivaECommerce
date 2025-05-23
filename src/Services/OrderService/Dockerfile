# Base image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# کپی فایل csproj
COPY ["OrderService.csproj", "./"]

# ریستور پکیج‌ها
RUN dotnet restore "OrderService.csproj"

# کپی باقی فایل‌ها
COPY . .

# کامپایل و پابلیش
RUN dotnet publish "OrderService.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrderService.dll"]
