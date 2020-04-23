FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["KTaseva.App/KTaseva.App.csproj", "KTaseva.App/"]
COPY ["KTaseva.Common/KTaseva.Common.csproj", "KTaseva.Common/"]
COPY ["KTaseva.Data/KTaseva.Data.csproj", "KTaseva.Data/"]
COPY ["KTaseva.Models/KTaseva.Models.csproj", "KTaseva.Models/"]
COPY ["KTaseva.Services.Mapping/KTaseva.Services.Mapping.csproj", "KTaseva.Services.Mapping/"]
COPY ["KTaseva.Services/KTaseva.Services.csproj", "KTaseva.Services/"]
COPY ["KTaseva.ViewModels/KTaseva.ViewModels.csproj", "KTaseva.ViewModels/"]

RUN dotnet restore "KTaseva.App/KTaseva.App.csproj"
COPY . .
WORKDIR "/src/KTaseva.App"
RUN dotnet build "KTaseva.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KTaseva.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KTaseva.App.dll"]