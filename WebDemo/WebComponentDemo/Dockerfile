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


## ����ʹ�õĻ�������
#FROM microsoft/dotnet:2.2-aspnetcore-runtime
## ������dotnet core Ӧ�ÿ����� ���� /app/ Ŀ¼��
#COPY wwwdemo/ /app/
## ���ù���Ŀ¼
#WORKDIR /app
## ���õ����˿�
#EXPOSE 80
## ָ��Ӧ����ڵ�
#ENTRYPOINT ["dotnet", "/app/WebComponentDemo.dll"]
#
## buile
## docker build -t zh417233956/mangouserselectiondemo:1.0.0 .
## ���ؾ��ķ�ʽ������
## docker  create -p 9310:80 --name mangouserselectiondemov1 zh417233956/mangouserselectiondemo:1.0.0