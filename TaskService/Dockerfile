FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY . .
RUN dotnet build
RUN apt-get update && apt-get install -y netcat-openbsd
ENTRYPOINT ["/bin/sh", "-c", "until nc -z sql-server-container 1433; do sleep 1; done && dotnet TaskService.dll"]