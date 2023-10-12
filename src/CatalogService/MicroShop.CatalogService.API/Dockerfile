#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CatalogService/MicroShop.CatalogService.API/MicroShop.CatalogService.API.csproj", "src/CatalogService/MicroShop.CatalogService.API/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Application.Features.ProductBrands/MicroShop.CatalogService.Application.Features.ProductBrands.csproj", "src/CatalogService/MicroShop.CatalogService.Application.Features.ProductBrands/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Core.Abstractions.Requests/MicroShop.CatalogService.Core.Abstractions.Requests.csproj", "src/CatalogService/MicroShop.CatalogService.Core.Abstractions.Requests/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Core.Interfaces.Database/MicroShop.CatalogService.Core.Interfaces.Database.csproj", "src/CatalogService/MicroShop.CatalogService.Core.Interfaces.Database/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Domain.Entities/MicroShop.CatalogService.Domain.Entities.csproj", "src/CatalogService/MicroShop.CatalogService.Domain.Entities/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Application.Features.Products/MicroShop.CatalogService.Application.Features.Products.csproj", "src/CatalogService/MicroShop.CatalogService.Application.Features.Products/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Application.DataTransferObjects/MicroShop.CatalogService.Application.DataTransferObjects.csproj", "src/CatalogService/MicroShop.CatalogService.Application.DataTransferObjects/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Application.Features.ProductTypes/MicroShop.CatalogService.Application.Features.ProductTypes.csproj", "src/CatalogService/MicroShop.CatalogService.Application.Features.ProductTypes/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Application.Services.Mapper/MicroShop.CatalogService.Application.Services.Mapper.csproj", "src/CatalogService/MicroShop.CatalogService.Application.Services.Mapper/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Core.Containers/MicroShop.CatalogService.Core.Containers.csproj", "src/CatalogService/MicroShop.CatalogService.Core.Containers/"]
COPY ["src/CatalogService/MicroShop.CatalogService.Database/MicroShop.CatalogService.Database.csproj", "src/CatalogService/MicroShop.CatalogService.Database/"]
RUN dotnet restore "src/CatalogService/MicroShop.CatalogService.API/MicroShop.CatalogService.API.csproj"
COPY . .
WORKDIR "/src/src/CatalogService/MicroShop.CatalogService.API"
RUN dotnet build "MicroShop.CatalogService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroShop.CatalogService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroShop.CatalogService.API.dll"]