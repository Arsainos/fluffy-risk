#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
USER ContainerAdministrator
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Aggregator/WebApi.Aggregator/WebApi.Aggregator/WebApi.Aggregator.csproj", "Aggregator/WebApi.Aggregator/WebApi.Aggregator/"]
RUN dotnet restore "Aggregator/WebApi.Aggregator/WebApi.Aggregator/WebApi.Aggregator.csproj"
COPY . .
WORKDIR "/src/Aggregator/WebApi.Aggregator/WebApi.Aggregator"
RUN dotnet tool install pfxtool -g && pfxtool import --file "Cerificates\fluffyapp.pfx" --password lakonos88 --scope user
RUN dotnet build "WebApi.Aggregator.csproj" -c Release -o /app/build
ENTRYPOINT ["pfxtool", "list", "--scope", "user"]

FROM build AS publish
RUN dotnet publish "WebApi.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.Aggregator.dll"]

##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["Aggregator/WebApi.Aggregator/WebApi.Aggregator/WebApi.Aggregator.csproj", "Aggregator/WebApi.Aggregator/WebApi.Aggregator/"]
#RUN dotnet restore "Aggregator/WebApi.Aggregator/WebApi.Aggregator/WebApi.Aggregator.csproj"
#COPY . .
#WORKDIR "/src/Aggregator/WebApi.Aggregator/WebApi.Aggregator"
#RUN dotnet build "WebApi.Aggregator.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "WebApi.Aggregator.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WebApi.Aggregator.dll"]