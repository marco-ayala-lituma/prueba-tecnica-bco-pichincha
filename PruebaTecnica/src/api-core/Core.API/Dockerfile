#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/api-core/Core.API/Core.API.csproj", "src/api-core/Core.API/"]
COPY ["src/api-core/Core.Application/Core.Application.csproj", "src/api-core/Core.Application/"]
COPY ["src/api-core/Core.Domain/Core.Domain.csproj", "src/api-core/Core.Domain/"]
COPY ["src/api-core/Core.Infrastructure/Core.Infrastructure.csproj", "src/api-core/Core.Infrastructure/"]
RUN dotnet restore "./src/api-core/Core.API/Core.API.csproj"
COPY . .
WORKDIR "/src/src/api-core/Core.API"
RUN dotnet build "./Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.API.dll"]