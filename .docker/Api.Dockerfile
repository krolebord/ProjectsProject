FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 44376

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["common.props", "./"]
WORKDIR /src
COPY ["src/ProjectsProject.HttpApi.Host/ProjectsProject.HttpApi.Host.csproj", "ProjectsProject.HttpApi.Host/"]
COPY ["src/ProjectsProject.Application/ProjectsProject.Application.csproj", "ProjectsProject.Application/"]
COPY ["src/ProjectsProject.Domain/ProjectsProject.Domain.csproj", "ProjectsProject.Domain/"]
COPY ["src/ProjectsProject.Domain.Shared/ProjectsProject.Domain.Shared.csproj", "ProjectsProject.Domain.Shared/"]
COPY ["src/ProjectsProject.Application.Contracts/ProjectsProject.Application.Contracts.csproj", "ProjectsProject.Application.Contracts/"]
COPY ["src/ProjectsProject.EntityFrameworkCore/ProjectsProject.EntityFrameworkCore.csproj", "ProjectsProject.EntityFrameworkCore/"]
COPY ["src/ProjectsProject.HttpApi/ProjectsProject.HttpApi.csproj", "ProjectsProject.HttpApi/"]
RUN dotnet restore "ProjectsProject.HttpApi.Host/ProjectsProject.HttpApi.Host.csproj"

COPY ["src/ProjectsProject.HttpApi.Host/", "ProjectsProject.HttpApi.Host/"]
COPY ["src/ProjectsProject.Application/", "ProjectsProject.Application/"]
COPY ["src/ProjectsProject.Domain/", "ProjectsProject.Domain/"]
COPY ["src/ProjectsProject.Domain.Shared/", "ProjectsProject.Domain.Shared/"]
COPY ["src/ProjectsProject.Application.Contracts/", "ProjectsProject.Application.Contracts/"]
COPY ["src/ProjectsProject.EntityFrameworkCore/", "ProjectsProject.EntityFrameworkCore/"]
COPY ["src/ProjectsProject.HttpApi/", "ProjectsProject.HttpApi/"]
WORKDIR "/src/ProjectsProject.HttpApi.Host"
RUN dotnet build "ProjectsProject.HttpApi.Host.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectsProject.HttpApi.Host.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectsProject.HttpApi.Host.dll"]
