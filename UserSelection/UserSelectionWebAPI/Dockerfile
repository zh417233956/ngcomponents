FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UserSelection/UserSelectionWebAPI/UserSelectionWebAPI.csproj", "UserSelection/UserSelectionWebAPI/"]
RUN dotnet restore "UserSelection/UserSelectionWebAPI/UserSelectionWebAPI.csproj"
COPY . .
WORKDIR "/src/UserSelection/UserSelectionWebAPI"
RUN dotnet build "UserSelectionWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserSelectionWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserSelectionWebAPI.dll"]


## 声明使用的基础镜像
#FROM microsoft/dotnet:2.2-aspnetcore-runtime
## 将本地dotnet core 应用拷贝到 容器 /app/ 目录下
#COPY wwwapi/ /app/
## 设置工作目录
#WORKDIR /app
## 设置导出端口
#EXPOSE 80
## 指定应用入口点
#ENTRYPOINT ["dotnet", "/app/UserSelectionWebAPI.dll"]
#
## buile
## docker build -t zh417233956/mangouserselectionapi:1.0.0 .
## 挂载卷的方式启动：
## docker  create -p 9300:5000 --name mangouserselectionapiv1 -v "/opt/UserSelectionWebAPI/wwwapi:/app" zh417233956/mangouserselectionapi:1.0.0
## docker run -it -p 9300:5000 --name mangouserselectionapiv1 -v "/opt/UserSelectionWebAPI/wwwapi:/app" zh417233956/mangouserselectionapi:1.0.0
