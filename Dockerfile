# Usa la imagen oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo .csproj y restaura solo las dependencias (optimiza caché)
COPY N5Now.Test.Api/*.csproj ./N5Now.Test.Api/
WORKDIR /src/N5Now.Test.Api
RUN dotnet restore

# Copia todo el código fuente y compila la aplicación
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

# Usa una imagen ligera de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expone puertos HTTP y HTTPS
EXPOSE 80
EXPOSE 443

# Comando de inicio
ENTRYPOINT ["dotnet", "N5Now.Test.Api.dll"]
