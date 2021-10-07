# EasyTemplateCore

A simple template for Asp.net core

IDE : VSCode ( Installed extensions : ms-dotnettools.csharp, ms-azuretools.vscode-docker)

Done:

******************************
The project is being developed
******************************
Active ( Will have):

Framework : ASP.NET Core

Localization

Globalization

## ORM : Entity Framework Core

To add your first migration, In web project folder, run the following command in VSCode Terminal or CMD:

``` bash

dotnet ef migrations add InitialCreate
```
###### More information :
[Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)


## Object mapper : Automapper
## Errors Log Library : Log Elmah
## Authentication : ASP.NET Core Identity
## Real-time web functionality : ASP.NET Core SignalR
## Platform as a service (PaaS) - Container : Docker
Download and install docker desktop:
(Docker Desktop)[https://www.docker.com/products/docker-desktop]

1- Create a Dockerfile in solution folder.
``` bash

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
```

```diff

!If you want to use Kubernetes, just run step 2 and 3 in part " Use it from docker hub image "
```


##### Use it from local image :

2- To Build the Docker Image, In solution folder, run the following command in VSCode Terminal or CMD:

```diff

- Don't forget to add . at the end of command
```

``` bash
docker build -t <Image name> .

# In this example :
docker build -t easytemplatecore .
```
3- To Run the Docker Image :

From local image: run the following command in VSCode Terminal or CMD:
``` bash
docker run -d -p 8080:80 easytemplatecore
```
##### Use it from docker hub image :
2- To Build the Docker Image, In solution folder, run the following command in VSCode Terminal or CMD:

``` bash
docker build -t <your_username>/<Image name> .

# In this example :
docker build -t <your_username>/easytemplatecore .
```
3- Push the Docker image to Docker Hub:
``` Bash
docker push <your_username>/my-private-repo
```
4- To Run the Docker Image :

From local image: run the following command in VSCode Terminal or CMD:

``` bash
docker run -d -p 8080:80 <your_username>/easytemplatecore
```
###### More information :
[Dockerize an ASP.NET Core application](https://docs.docker.com/samples/dotnetcore/)

[Docker Hub Quickstart](https://docs.docker.com/docker-hub/)

[Set up Automated Builds](https://docs.docker.com/docker-hub/builds/)

[GitHub Action CI/CD pipeline with Docker containers](https://docs.docker.com/ci-cd/github-actions/)

[Deploy a registry server](https://docs.docker.com/registry/deploying/)

[Docker Hub Quickstart](https://docs.docker.com/docker-hub/)

[Docker Cheat Sheet](https://github.com/wsargent/docker-cheat-sheet)

## Orchestration Managing containers : Kubernetes
To enable Kubernetes support and install a standalone instance of Kubernetes running as a Docker container, on Docker Dektop, go to Preferences > Kubernetes and then click Enable Kubernetes.
Deploying the Dashboard UI for Kubernetes:

[Deploy and Access the Kubernetes Dashboard](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/)


###### More information :
[Deploy on Kubernetes](https://docs.docker.com/desktop/kubernetes/)

[Kubernetes on Windows](https://docs.microsoft.com/en-us/virtualization/windowscontainers/kubernetes/getting-started-kubernetes-windows)

[Install and Set Up kubectl on Windows](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)

[Adding Windows nodes](https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/adding-windows-nodes/)

[Kubernetes Cluster On Windows Server Worker Nodes](https://www.hostafrica.co.za/blog/new-technologies/install-kubernetes-cluster-windows-server-worker-nodes)

[Windows containers on Azure Kubernetes](https://docs.microsoft.com/en-us/azure/aks/windows-container-cli)
[Kubernetes on AWS](https://aws.amazon.com/kubernetes/)
[Google Kubernetes Engine](https://cloud.google.com/kubernetes-engine)

## RPC framework : GRPC
## Sysnch Consume APIs : HTTP Client
## Message broker : RabbitMQ
## Datbase : SQL Server (Always on)
## Datbase : PostgreSql
## Datbase : MongoDb
## Distributed Cache : Redis
## Command and Query : CQRS
## search and analytics engine : Elasticsearch
## IDL - Describing REST APIs : Swagger
## UnitTest : NUnit
## Integrated Test : FakeHttpContext
## Mocking library : Moq
## Test API : Postman

## Traffic routing controller : Ingress
## CI/CD : github Actions
## Cloud Services : AWS
## License

[MIT](https://choosealicense.com/licenses/mit/)