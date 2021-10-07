
# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy all csproj files and restore as distinct layers
COPY ["src/EasyTemplateCore.Web/EasyTemplateCore.Web.csproj", "src/EasyTemplateCore.Web/"]
COPY ["src/EasyTemplateCore.Services/EasyTemplateCore.Services.csproj", "src/EasyTemplateCore.Services/"]
COPY ["src/EasyTemplateCore.Data/EasyTemplateCore.Data.csproj", "src/EasyTemplateCore.Data/"]
COPY ["src/EasyTemplateCore.Entities/EasyTemplateCore.Entities.csproj", "src/EasyTemplateCore.Entities/"]
COPY ["src/EasyTemplateCore.Dtos/EasyTemplateCore.Dtos.csproj", "src/EasyTemplateCore.Dtos/"]
RUN dotnet restore "src/EasyTemplateCore.Web/EasyTemplateCore.Web.csproj"
COPY . .

# Build and Publish
WORKDIR "/src/src/EasyTemplateCore.Web"
RUN dotnet build "EasyTemplateCore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyTemplateCore.Web.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyTemplateCore.Web.dll"]