FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Command.Api/Command.Api.csproj", "Command.Api/"]
COPY ["Command.App/Command.App.csproj", "Command.App/"]
COPY ["Command.Domain/Command.Domain.csproj", "Command.Domain/"]
COPY ["Command.Infrastructure/Command.Infrastructure.csproj", "Command.Infrastructure/"]
RUN dotnet restore "Command.Api/Command.Api.csproj"
COPY . .
WORKDIR "/src/Command.Api"
RUN dotnet build "Command.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Command.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Command.Api.dll"]