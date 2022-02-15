FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["teste-api/src/TesteApi.Api/TesteApi.Api.csproj", "teste-api/src/TesteApi.Api/"]
COPY ["teste-api/src/TesteApi.Service/TesteApi.Service.csproj", "teste-api/src/TesteApi.Service/"]
COPY ["teste-api/src/TesteApi.Domain/TesteApi.Domain.csproj", "teste-api/src/TesteApi.Domain/"]
COPY ["teste-api/src/TesteApi.Infra/TesteApi.Infra.csproj", "teste-api/src/TesteApi.Infra/"]
RUN dotnet restore "teste-api/src/TesteApi.Api/TesteApi.Api.csproj"
COPY . .
WORKDIR "/src/teste-api/src/TesteApi.Api"
RUN dotnet build "TesteApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteApi.Api.dll"]