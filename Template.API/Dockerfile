FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Template/Template.API/Template.API.csproj", "Services/Template/Template.API/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Services/Template/Template.Domain/Template.Domain.csproj", "Services/Template/Template.Domain/"]
COPY ["Services/Template/Template.Infrastructure/Template.Infrastructure.csproj", "Services/Template/Template.Infrastructure/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/Template/Template.API/"
COPY . .
WORKDIR "/src/Services/Template/Template.API"
RUN dotnet build "Template.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Template.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Template.API.dll"]
