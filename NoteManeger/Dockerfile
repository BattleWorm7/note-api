# Базовый образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем всё из репозитория
COPY . .

# Переходим в папку, где .csproj файл
WORKDIR /src/NoteManager

# Восстановление зависимостей
RUN dotnet restore

# Сборка
RUN dotnet publish -c Release -o /app/publish

# Runtime-образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# Настройки для Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "NoteManager.dll"]