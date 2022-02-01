FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/web-demo

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
RUN apk add curl
WORKDIR /app
COPY --from=build /app/web-demo /app

HEALTHCHECK --interval=10s CMD curl --fail http://localhost:80/you-up || exit 1

ENTRYPOINT [ "dotnet", "Demo.WebApp.dll" ]