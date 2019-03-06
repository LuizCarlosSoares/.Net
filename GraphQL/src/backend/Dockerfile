FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["gql.api/gql.api.csproj", "gql.api/"]
RUN dotnet restore "gql.api/gql.api.csproj"
COPY . .
WORKDIR "/src/gql.api"
RUN dotnet build "gql.api.csproj" -c Debug -o /app

FROM build AS publish
RUN dotnet publish "gql.api.csproj" -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "gql.api.dll"]
