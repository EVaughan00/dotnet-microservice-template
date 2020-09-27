FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Identity/API/API.csproj", "Services/Identity/API/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Services/Identity/Domain/Domain.csproj", "Services/Identity/Domain/"]
COPY ["Services/Identity/Infrastructure/Infrastructure.csproj", "Services/Identity/Infrastructure/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/Identity/API/"
COPY . .
WORKDIR "/src/Services/Identity/API"
RUN dotnet build "API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]
