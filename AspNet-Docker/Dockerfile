FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY sampleapp/*.csproj ./sampleapp/
RUN dotnet restore

# copy everything else and build app
COPY sampleapp/. ./sampleapp/
WORKDIR /app/sampleapp
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/sampleapp/out ./
ENTRYPOINT ["dotnet", "sampleapp.dll"]
