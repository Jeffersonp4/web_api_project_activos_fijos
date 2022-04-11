FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
RUN sed -i 's/TLSv1.2/TLSv1/g' /etc/ssl/openssl.cnf
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web-api-project-activos-fijos.csproj", "./"]
RUN dotnet restore "web-api-project-activos-fijos.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "web-api-project-activos-fijos.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "web-api-project-activos-fijos.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet web-api-project-activos-fijos.dll