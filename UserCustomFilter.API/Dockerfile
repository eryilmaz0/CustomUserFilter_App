FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserCustomFilter.API/UserCustomFilter.API.csproj", "UserCustomFilter.API/"]
RUN dotnet restore "UserCustomFilter.API/UserCustomFilter.API.csproj"
COPY . .
WORKDIR "/src/UserCustomFilter.API"
RUN dotnet build "UserCustomFilter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserCustomFilter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserCustomFilter.API.dll"]
