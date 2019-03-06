FROM microsoft/dotnet:2.1-sdk
ENV NUGET_XMLDOC_MODE skip
WORKDIR /vsdbg

# Installing vsdbg debbuger into our container 
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
       unzip \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

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
RUN dotnet publish gql.api.csproj -c Debug -o out


#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
#WORKDIR /app/gqlapp
#COPY --from=build /app/gqlapp/out ./
#ENTRYPOINT ["dotnet", "gql.api.dll"]
ENTRYPOINT ["/bin/bash", "-c", "sleep infinity"]