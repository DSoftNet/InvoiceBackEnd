FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Invoice.Api/Invoice.Api.csproj", "Invoice.Api/"]
RUN dotnet restore "Invoice.Api/Invoice.Api.csproj"
COPY . .
WORKDIR "/src/Invoice.Api"
RUN dotnet build "Invoice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Invoice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Invoice.Api.dll"]
