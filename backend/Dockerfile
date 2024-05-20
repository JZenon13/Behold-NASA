# backend/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build-env /app/out .
COPY --from=build-env /app/api ./api

EXPOSE 5000

ENTRYPOINT ["dotnet", "NASA_BE.dll"]