FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY gql.api/*.csproj ./gql.api/
COPY gql.core/*.csproj ./gql.core/
COPY gql.data/*.csproj ./gql.data/

RUN dotnet restore

# copy everything else and build app
COPY gql.core/. ./gqlapp/
COPY gql.data/. ./gqlapp/
COPY gql.api/. ./gqlapp/
WORKDIR /app/gqlapp
#RUN  ls -a 
RUN dotnet publish gql.api.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app/gqlapp
COPY --from=build /app/gqlapp/out ./
ENTRYPOINT ["dotnet", "gql.api.dll"]
