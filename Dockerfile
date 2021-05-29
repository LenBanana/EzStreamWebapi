FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PopcornWebapi/PopcornWebapi.csproj", "PopcornWebapi/"]
RUN dotnet restore "PopcornWebapi/PopcornWebapi.csproj"
COPY . .
WORKDIR "/src/PopcornWebapi"
RUN dotnet build "PopcornWebapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PopcornWebapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PopcornWebapi.dll"]