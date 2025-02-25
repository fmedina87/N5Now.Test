# Usa la imagen oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo de solución y restaura las dependencias
COPY ["N5Now.Test.sln", "./"]
COPY ["N5Now.Test.Api/N5Now.Test.Api.csproj", "N5Now.Test.Api/"]
COPY ["N5Now.Test.Application/N5Now.Test.Application.csproj", "N5Now.Test.Application/"]
COPY ["N5Now.Test.Domain/N5Now.Test.Domain.csproj", "N5Now.Test.Domain/"]
COPY ["N5Now.Test.Infrastructure/N5Now.Test.Infrastructure.csproj", "N5Now.Test.Infrastructure/"]

# Restaurar paquetes
RUN dotnet restore "N5Now.Test.sln"

# Copiar el código fuente y compilar
COPY . .
WORKDIR /src/N5Now.Test.Api
RUN dotnet publish "N5Now.Test.Api.csproj" -c Release -o /app/publish --no-restore

# Imagen final con .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expone el puerto 80 para HTTP
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "N5Now.Test.Api.dll"]