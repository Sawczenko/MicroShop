#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/IdentityService/MicroShop.IdentityService.API/MicroShop.IdentityService.API.csproj", "src/IdentityService/MicroShop.IdentityService.API/"]
RUN dotnet restore "src/IdentityService/MicroShop.IdentityService.API/MicroShop.IdentityService.API.csproj"
COPY . .
WORKDIR "/src/src/IdentityService/MicroShop.IdentityService.API"
RUN dotnet build "MicroShop.IdentityService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroShop.IdentityService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroShop.IdentityService.API.dll"]