FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeatherAssignment.Application/WeatherAssignment.Application.csproj", "WeatherAssignment.Application/"]
COPY ["WeatherAssignment.Core/WeatherAssignment.Core.csproj", "WeatherAssignment.Core/"]
COPY ["WeatherAssignment.Infrastructure/WeatherAssignment.Infrastructure.csproj", "WeatherAssignment.Infrastructure/"]
COPY ["WeatherAssignment.Web/WeatherAssignment.Web.csproj", "WeatherAssignment.Web/"]
RUN dotnet restore "WeatherAssignment.Web/WeatherAssignment.Web.csproj"
COPY . .
WORKDIR "/src/WeatherAssignment.Web"
RUN dotnet build "WeatherAssignment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WeatherAssignment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherAssignment.Web.dll"]