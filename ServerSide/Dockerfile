FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ServerSide/ServerSide.csproj", "ServerSide/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Directory.build.props", "ServerSide/."]
RUN dotnet restore "ServerSide/ServerSide.csproj"
WORKDIR "/src/ServerSide"
RUN dotnet build "ServerSide.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerSide.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerSide.dll"]