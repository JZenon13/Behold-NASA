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

ENV API_KEY=lbQUIeW4KfUfLuQ4cPX2fVTJfMeRKEQENed8vyn2
ENV BASE_URL=https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=2015-6-3&api_key=DEMO_KEY

EXPOSE 8000

ENTRYPOINT ["dotnet", "NASA_BE.dll"]