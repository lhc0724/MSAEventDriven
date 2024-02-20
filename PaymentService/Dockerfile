FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT="Production"
ENV ASPNETCORE_HTTP_PORTS=80
ENV LANG C.UTF-8
ENV LC_ALL C.UTF-8

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["NuGet.config", "./"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["PaymentService/PaymentService.csproj", "PaymentService/"]

RUN dotnet restore --configfile NuGet.config "PaymentService/PaymentService.csproj"

COPY . .
WORKDIR "/src/PaymentService"
RUN dotnet build "PaymentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentService.dll"]

