# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todos os projetos
COPY src/Producer/ComponentConsumption.Producer/ComponentConsumption.Producer.csproj ComponentConsumption.Producer/
COPY src/Producer/ComponentConsumption.Application/ComponentConsumption.Application.csproj ComponentConsumption.Application/
COPY src/Producer/ComponentConsumption.Infrastructure/ComponentConsumption.Infrastructure.csproj ComponentConsumption.Infrastructure/
COPY src/Producer/ComponentConsumption.Shared/ComponentConsumption.Shared.csproj ComponentConsumption.Shared/
COPY src/Producer/ComponentConsumption.Model/ComponentConsumption.Model.csproj ComponentConsumption.Model/

# Restaurar pacotes
RUN dotnet restore ComponentConsumption.Producer/ComponentConsumption.Producer.csproj

# Copiar todo o código
COPY src/Producer/ComponentConsumption.Producer/ ComponentConsumption.Producer/
COPY src/Producer/ComponentConsumption.Application/ ComponentConsumption.Application/
COPY src/Producer/ComponentConsumption.Infrastructure/ ComponentConsumption.Infrastructure/
COPY src/Producer/ComponentConsumption.Shared/ ComponentConsumption.Shared/
COPY src/Producer/ComponentConsumption.Model/ ComponentConsumption.Model/

# Publicar
RUN dotnet publish ComponentConsumption.Producer/ComponentConsumption.Producer.csproj -c Release -o /app

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar appsettings
COPY src/Producer/ComponentConsumption.Producer/appsettings.json ./

# Copiar build final
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "ComponentConsumption.Producer.dll"]
