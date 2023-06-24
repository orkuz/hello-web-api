FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["hello-web-api.csproj", "./"]
RUN dotnet restore "./hello-web-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "hello-web-api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "hello-web-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hello-web-api.dll"]