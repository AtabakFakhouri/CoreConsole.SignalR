# CoreConsoleApp-SignalR
Example SignalR running in server/client dotnet core console app using hostedservice

## Getting Started

### Prerequisites

* Docker
* dotnetcore

## Running the tests on docker

Go to server root path

```cmd
docker build --rm -t coreconsole.signalr.server:latest .
docker run --rm -p 80:80 -i -t coreconsole.signalr.server:latest /bin/bash
```

Then go to client root path
```cmd
docker build --rm -t coreconsole.signalr.client:latest .
docker run -i -t coreconsole.signalr.client:latest /bin/bash
```

## Built With

* [docker](https://www.docker.com) - Docker
* [aspnetcore](https://docs.microsoft.com/pt-br/aspnet/core/) - Aspnet Core
* [signalr](https://dotnet.microsoft.com/apps/aspnet/real-time) - SignalR

## Authors

* **Atabak Fakhouri Tabrizi** - *Sample Project* - [atabakfakhouri](https://github.com/AtabakFakhouri)
