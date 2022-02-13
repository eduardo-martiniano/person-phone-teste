FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/TesteApi.Api/TesteApi.Api.csproj", "src/TesteApi.Api/"]
COPY ["src/TesteApi.Service/TesteApi.Service.csproj", "src/TesteApi.Service/"]
COPY ["src/TesteApi.Domain/TesteApi.Domain.csproj", "src/TesteApi.Domain/"]
COPY ["src/TesteApi.Infra/TesteApi.Infra.csproj", "src/TesteApi.Infra/"]
RUN dotnet restore "src/TesteApi.Api/TesteApi.Api.csproj"
COPY . .
WORKDIR "/src/src/TesteApi.Api"
RUN dotnet build "TesteApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteApi.Api.dll"]