FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Template/API/API.csproj", "Services/Template/API/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Services/Template/Domain/Domain.csproj", "Services/Template/Domain/"]
COPY ["Services/Template/Infrastructure/Infrastructure.csproj", "Services/Template/Infrastructure/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/Template/API/"
COPY . .
WORKDIR "/src/Services/Template/API"
RUN dotnet build "API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]
