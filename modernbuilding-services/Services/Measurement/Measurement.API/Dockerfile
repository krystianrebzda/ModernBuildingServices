#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Measurement/Measurement.API/Measurement.API.csproj", "Services/Measurement/Measurement.API/"]
RUN dotnet restore "Services/Measurement/Measurement.API/Measurement.API.csproj"
COPY . .
WORKDIR "/src/Services/Measurement/Measurement.API"
RUN dotnet build "Measurement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Measurement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Measurement.API.dll"]
