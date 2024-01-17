FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["adminBlazor.Api/adminBlazor.Api.csproj", "adminBlazor.Api/"]
RUN dotnet restore "adminBlazor.Api/adminBlazor.Api.csproj"
COPY . .
WORKDIR "/src/adminBlazor.Api"
RUN dotnet build "adminBlazor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "adminBlazor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "adminBlazor.Api.dll"]
