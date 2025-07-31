# 1. Базовый образ .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. Копируем всё из подпапки проекта
COPY . .

# 3. Переход в папку с .csproj
WORKDIR /src/NoteManager

# 4. Восстановление зависимостей
RUN dotnet restore

# 5. Сборка и публикация
RUN dotnet publish -c Release -o /app/publish

# 6. Runtime-образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "NoteManager.dll"]