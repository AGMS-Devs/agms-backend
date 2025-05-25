# .NET 8.0 SDK ile build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Solution ve proje dosyalarını kopyala
COPY AGMS/AGMS.sln ./AGMS/
COPY AGMS/src/aGMS/Domain/Domain.csproj ./AGMS/src/aGMS/Domain/
COPY AGMS/src/aGMS/Application/Application.csproj ./AGMS/src/aGMS/Application/
COPY AGMS/src/aGMS/Infrastructure/Infrastructure.csproj ./AGMS/src/aGMS/Infrastructure/
COPY AGMS/src/aGMS/Persistence/Persistence.csproj ./AGMS/src/aGMS/Persistence/
COPY AGMS/src/aGMS/WebAPI/WebAPI.csproj ./AGMS/src/aGMS/WebAPI/

# Dependencies restore
WORKDIR /src/AGMS
RUN dotnet restore

# Tüm kaynak kodu kopyala
WORKDIR /src
COPY AGMS/ ./AGMS/

# Build ve publish
WORKDIR /src/AGMS/src/aGMS/WebAPI
RUN dotnet publish -c Release -o /app/publish --no-restore

# .NET 8.0 ASP.NET Core runtime ile çalıştırma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# SSL sertifikası için gerekli
RUN apt-get update && apt-get install -y ca-certificates && rm -rf /var/lib/apt/lists/*

# Published files kopyala
COPY --from=build /app/publish .

# Port açılımı
EXPOSE 8080

# Entry point
ENTRYPOINT ["dotnet", "WebAPI.dll"] 