FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CoreConsole.SignalR.Client.csproj", "."]
RUN dotnet restore "./CoreConsole.SignalR.Client.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CoreConsole.SignalR.Client.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "CoreConsole.SignalR.Client.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreConsole.SignalR.Client.dll"]