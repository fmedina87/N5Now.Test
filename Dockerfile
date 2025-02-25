# Usa la imagen oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia todo el código fuente y compila la aplicación
COPY . ./
RUN dotnet publish -c Release -o /out

# Usa una imagen ligera de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Expone el puerto 80 para acceso HTTP
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "N5Now.Test.Api.dll"]
