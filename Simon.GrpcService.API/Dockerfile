#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Simon.GrpcService.API/Simon.GrpcService.API.csproj", "Simon.GrpcService.API/"]
COPY ["NuGet.config", "./"]
RUN dotnet restore "Simon.GrpcService.API/Simon.GrpcService.API.csproj"
COPY . .
WORKDIR "/src/Simon.GrpcService.API"
RUN dotnet build "Simon.GrpcService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simon.GrpcService.API.csproj" -c Release -o /app/publish

FROM base AS final
ENV TZ Asia/Shanghai
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simon.GrpcService.API.dll"]