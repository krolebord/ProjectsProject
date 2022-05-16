FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 44377

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["common.props", "./"]
WORKDIR /src
COPY ["src/ProjectsProject.Blazor/ProjectsProject.Blazor.csproj", "ProjectsProject.Blazor/"]
COPY ["packages/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme.csproj", "../packages/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme/"]
COPY ["packages/Volo.Abp.AspNetCore.Components.Web.BasicTheme/Volo.Abp.AspNetCore.Components.Web.BasicTheme.csproj", "../packages/Volo.Abp.AspNetCore.Components.Web.BasicTheme/"]
COPY ["src/ProjectsProject.HttpApi.Client/ProjectsProject.HttpApi.Client.csproj", "ProjectsProject.HttpApi.Client/"]
COPY ["src/ProjectsProject.Application.Contracts/ProjectsProject.Application.Contracts.csproj", "ProjectsProject.Application.Contracts/"]
COPY ["src/ProjectsProject.Domain.Shared/ProjectsProject.Domain.Shared.csproj", "ProjectsProject.Domain.Shared/"]
RUN dotnet restore "ProjectsProject.Blazor/ProjectsProject.Blazor.csproj"
COPY ["src/ProjectsProject.Blazor/", "ProjectsProject.Blazor/"]
COPY ["packages/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme/", "../packages/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme/"]
COPY ["packages/Volo.Abp.AspNetCore.Components.Web.BasicTheme/", "../packages/Volo.Abp.AspNetCore.Components.Web.BasicTheme/"]
COPY ["src/ProjectsProject.HttpApi.Client/", "ProjectsProject.HttpApi.Client/"]
COPY ["src/ProjectsProject.Application.Contracts/", "ProjectsProject.Application.Contracts/"]
COPY ["src/ProjectsProject.Domain.Shared/", "ProjectsProject.Domain.Shared/"]
WORKDIR "/src/ProjectsProject.Blazor"
RUN dotnet build "ProjectsProject.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectsProject.Blazor.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY /src/ProjectsProject.Blazor/nginx.conf /etc/nginx/nginx.conf
