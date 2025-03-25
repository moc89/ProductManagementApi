﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductManagement.Api/ProductManagement.Api.csproj", "ProductManagement.Api/"]
COPY ["ProductManagement.Services/ProductManagement.Services.csproj", "ProductManagement.Services/"]
COPY ["ProductManagement.Repository/ProductManagement.Repository.csproj", "ProductManagement.Repository/"]
RUN dotnet restore "ProductManagement.Api/ProductManagement.Api.csproj"
COPY . .
WORKDIR "/src/ProductManagement.Api"
RUN dotnet build "ProductManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductManagement.Api.dll"]
