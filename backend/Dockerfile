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

ENV API_KEY=lbQUIeW4KfUfLuQ4cPX2fVTJfMeRKEQENed8vyn2
ENV BASE_URL=https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=
ENV FRONT_END=http://localhost:5173/


EXPOSE 5000

ENTRYPOINT ["dotnet", "NASA_BE.dll"]