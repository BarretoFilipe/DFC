#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DFCApi/DFCApi.csproj", "DFCApi/"]
RUN dotnet restore "DFCApi/DFCApi.csproj"
COPY . .
WORKDIR "/src/DFCApi"
RUN dotnet build "DFCApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DFCApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DFCApi.dll"]