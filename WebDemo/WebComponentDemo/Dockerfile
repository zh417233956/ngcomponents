FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebDemo/WebComponentDemo/WebComponentDemo.csproj", "WebDemo/WebComponentDemo/"]
COPY ["WebGatewayDLL/WebComponentAPIGateway/WebComponentAPIGateway.csproj", "WebGatewayDLL/WebComponentAPIGateway/"]
RUN dotnet restore "WebDemo/WebComponentDemo/WebComponentDemo.csproj"
COPY . .
WORKDIR "/src/WebDemo/WebComponentDemo"
RUN dotnet build "WebComponentDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebComponentDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebComponentDemo.dll"]


## 声明使用的基础镜像
#FROM microsoft/dotnet:2.2-aspnetcore-runtime
## 将本地dotnet core 应用拷贝到 容器 /app/ 目录下
#COPY wwwdemo/ /app/
## 设置工作目录
#WORKDIR /app
## 设置导出端口
#EXPOSE 80
## 指定应用入口点
#ENTRYPOINT ["dotnet", "/app/WebComponentDemo.dll"]
#
## buile
## docker build -t zh417233956/mangouserselectiondemo:1.0.0 .
## 挂载卷的方式启动：
## docker  create -p 9310:80 --name mangouserselectiondemov1 zh417233956/mangouserselectiondemo:1.0.0