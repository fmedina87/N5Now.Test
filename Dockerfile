# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar el archivo de solución y restaurar dependencias
COPY ["N5Now.Test.sln", "./"]
COPY ["N5Now.Test.Api/N5Now.Test.Api.csproj", "N5Now.Test.Api/"]
COPY ["N5Now.Test.Application/N5Now.Test.Application.csproj", "N5Now.Test.Application/"]
COPY ["N5Now.Test.Domain/N5Now.Test.Domain.csproj", "N5Now.Test.Domain/"]
COPY ["N5Now.Test.Infrastructure/N5Now.Test.Infrastructure.csproj", "N5Now.Test.Infrastructure/"]

RUN dotnet restore

# Copiar el resto del código fuente y compilar
COPY . .
WORKDIR "/src/N5Now.Test.Api"
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "N5Now.Test.Api.dll"]
