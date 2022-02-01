# Demo Web App

This demo contains and .NET 6.0 web application with a background service and health checks presented by an API as well as using HEALTHCHECK in the Docker container.

## Worker

The worker is adding a logging entry every 1 second.

## Health Checks

The health checks can be accessed via the /you-up path on whatever URL the site is hosted.  It will return **Healthy** if the current DateTime minute is even, otherwise it returns **Unhealty**.  When the health check is **Unhealty**, it will write a Error to the log.

URLs:
- Local: https://localhost:7076/you-up
- Docker: https://localhost:8081/you-up

## Endpoints

Endpoints are defined in Program.cs using Minimal APIs.

- / - returns "Hello World"
- /you-up - health check status that returns Healthy or Unhealthy
- /about - returns OS Version and Environment variables for testing and diagnostics purposes

## Dockerize It

The project contains a Docker file that can be run with the following commands

```
docker build . -t web-app-health-demo

docker run --name web-app-health-demo -p 8081:80 -d web-app-health-demo
```