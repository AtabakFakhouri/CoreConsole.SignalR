FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CoreConsole.SignalR.Server.csproj", "."]
RUN dotnet restore "./CoreConsole.SignalR.Server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CoreConsole.SignalR.Server.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "CoreConsole.SignalR.Server.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreConsole.SignalR.Server.dll"]