# EasyTemplateCore

An Open Source and Simple Web Application Framework for ASP.NET Core Based on MicroServices 

IDE : VSCode ( Installed extensions : ms-dotnettools.csharp, ms-azuretools.vscode-docker)

Done:

******************************
The project is being developed
******************************
## Table Of Content

* [Asp.net core](https://github.com/MohsenM01/EasyTemplateCore#aspnet-core)
* [ORM : Entity Framework Core](https://github.com/MohsenM01/EasyTemplateCore#orm--entity-framework-core)
* [Object mapper : Automapper](https://github.com/MohsenM01/EasyTemplateCore#object-mapper--automapper)
* [Errors Log Library : Log Elmah](https://github.com/MohsenM01/EasyTemplateCore#errors-log-library--log-elmah)
* [Authentication : ASP.NET Core Identity](https://github.com/MohsenM01/EasyTemplateCore#authentication--aspnet-core-identity)
* [Authentication : JWT](https://github.com/MohsenM01/EasyTemplateCore#authentication--jwt)
* [Real-time web functionality : ASP.NET Core SignalR](https://github.com/MohsenM01/EasyTemplateCore#real-time-web-functionality--aspnet-core-signalr)
* [Platform as a service (PaaS) - Container : Docker](https://github.com/MohsenM01/EasyTemplateCore#platform-as-a-service-paas---container--docker)
    - [Using local image](https://github.com/MohsenM01/EasyTemplateCore#use-it-from-local-image-)
    - [Using Docker hub image](https://github.com/MohsenM01/EasyTemplateCore#use-it-from-docker-hub-image-)
* [Orchestration Managing containers : Kubernetes](https://github.com/MohsenM01/EasyTemplateCore#orchestration-managing-containers--kubernetes)
  - [Deploying the Dashboard UI for Kubernetes](https://github.com/MohsenM01/EasyTemplateCore#deploying-the-dashboard-ui-for-kubernetes)
* [Datbase : SQL Server (Always on)](https://github.com/MohsenM01/EasyTemplateCore#datbase--sql-server-always-on)
* [Deploy RabbitMQ on Kubernetes](https://github.com/MohsenM01/EasyTemplateCore#deploy-rabbitmq-on-kubernetes)
* [Traffic routing : NGINX Ingress Controller](https://github.com/MohsenM01/EasyTemplateCore#traffic-routing--nginx-ingress-controller)
  - [Edit Your Hosts File on Windows to route example.com](https://github.com/MohsenM01/EasyTemplateCore#edit-your-hosts-file-on-windows-to-route-examplecom)
* [RPC framework : GRPC](https://github.com/MohsenM01/EasyTemplateCore#rpc-framework--grpc)
* [Sysnch Consume APIs : HTTP Client](https://github.com/MohsenM01/EasyTemplateCore#sysnch-consume-apis--http-client)
* [Message broker : RabbitMQ](https://github.com/MohsenM01/EasyTemplateCore#message-broker--rabbitmq)
* [Datbase : PostgreSql](https://github.com/MohsenM01/EasyTemplateCore#datbase--postgresql)
* [Datbase : MongoDb](https://github.com/MohsenM01/EasyTemplateCore#datbase--mongodb)
* [Distributed Cache : Redis](https://github.com/MohsenM01/EasyTemplateCore#distributed-cache--redis)
  - [HybridCachingProvider : EasyCaching](https://github.com/MohsenM01/EasyTemplateCore#todo--hybridcachingprovider--easycaching)
* [Command and Query : CQRS](https://github.com/MohsenM01/EasyTemplateCore#command-and-query--cqrs)
* [search and analytics engine : Elasticsearch](https://github.com/MohsenM01/EasyTemplateCore#search-and-analytics-engine--elasticsearch)
* [IDL - Describing REST APIs : Swagger](https://github.com/MohsenM01/EasyTemplateCore#idl---describing-rest-apis--swagger)
* [Deploy EasyTemplateCore on Kubernetes](https://github.com/MohsenM01/EasyTemplateCore#deploy-easytemplatecore-on-kubernetes)
  - [Deploy LateralApp on Kubernetes](https://github.com/MohsenM01/EasyTemplateCore#deploy-lateralapp-on-kubernetes)
* [UnitTest : NUnit](https://github.com/MohsenM01/EasyTemplateCore#unittest--nunit)
* [Integrated Test : xUnit](https://github.com/MohsenM01/EasyTemplateCore#integrated-test--xunit)
* [Test API : Postman](https://github.com/MohsenM01/EasyTemplateCore#test-api--postman)
* [CI/CD : github Actions](https://github.com/MohsenM01/EasyTemplateCore#cicd--github-actions)
* [Image repository : Docker hub](https://github.com/MohsenM01/EasyTemplateCore#image-repository--docker-hub)
* [Cloud Services : AWS](https://github.com/MohsenM01/EasyTemplateCore#cloud-services--aws)


Active ( Will have):

Localization

Globalization

## Asp.net core

###### More information :

(ASP.NET documentation)[https://docs.microsoft.com/en-us/aspnet/core/]

(Handle errors in ASP.NET Core)[https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling]

## ORM : Entity Framework Core

What is it?

EF Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases through a provider plugin API.

Why we use it (Advantages, Disadvantage)?

EF Core can serve as an object-relational mapper (O/RM), which:
Enables .NET developers to work with a database using .NET objects.
Eliminates the need for most of the data-access code that typically needs to be written.

EF Core supports many database engines, see [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/) for details.

How we use it?
[Getting Started with EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app)

To add your first migration, In web project folder, run the following command in VSCode Terminal or CMD:

``` bash
dotnet ef migrations add InitialCreate
```
###### More information :

[Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)


## Object mapper : Automapper
What is it?

AutoMapper is a simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another

Why should we use it (Advantages, Disadvantage)?

Mapping code is boring. Testing mapping code is even more boring. AutoMapper provides simple configuration of types, as well as simple testing of mappings. The real question may be “why use object-object mapping?” Mapping can occur in many places in an application, but mostly in the boundaries between layers, such as between the UI/Domain layers, or Service/Domain layers. Concerns of one layer often conflict with concerns in another, so object-object mapping leads to segregated models, where concerns for each layer can affect only types in that layer.

How can we use it?
[Getting Started Guide with AutoMapper](https://docs.automapper.org/en/stable/Getting-started.html)


#### More information :

[ASP.NET Core Example using AutoMapper](https://docs.automapper.org/en/stable/Dependency-injection.html)

## Errors Log Library : Log Elmah

#### More information : 

[Using ElmahCore](https://github.com/ElmahCore/ElmahCore)

## Authentication : ASP.NET Core Identity

#### More information : 

[Overview of ASP.NET Core authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication)

[Introduction to Identity on ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)

[Migrate Authentication and Identity to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/migration/identity)

[Two-factor authentication using SMS and email with ASP.NET Identity](https://docs.microsoft.com/en-us/aspnet/identity/overview/features-api/two-factor-authentication-using-sms-and-email-with-aspnet-identity)

## Authentication : JWT

#### More information : 

[Overview of ASP.NET Core authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication)

## Real-time web functionality : ASP.NET Core SignalR

#### More information : 

[Introduction to ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction)

[Tutorial: Get started with ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr)


## Platform as a service (PaaS) - Container : Docker
Download and install docker desktop:

[Docker Desktop](https://www.docker.com/products/docker-desktop)

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

##### Using local image :

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
##### Using docker hub image :
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

**IMPORTANT** If Kubernetes doesn't run, Edit your Hosts File, by these steps:

1- Open up the Hosts file using Notepad:
```
c:\windows\system32\drivers\etc\hosts
```
2- Add this line at the end of the file:
```
# To allow the same kube context to work on the host and the container:
127.0.0.1 kubernetes.docker.internal
# End of section
```

### Deploying the Dashboard UI for Kubernetes:
1- Run the following command:

``` bash

kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.3.1/aio/deploy/recommended.yaml
```

2- To create sample user and a Service Account copy the following commands to new manifest file like `kube-dashboard-adminuser.yaml` and use `kubectl apply -f kube-dashboard-adminuser.yaml` command to create them.

```yaml
apiVersion: v1
kind: ServiceAccount
metadata:
  name: admin-user
  namespace: kubernetes-dashboard
---
apiVersion: rbac.authorization.k8s.io/v1
kind: ClusterRoleBinding
metadata:
  name: admin-user
roleRef:
  apiGroup: rbac.authorization.k8s.io
  kind: ClusterRole
  name: cluster-admin
subjects:
- kind: ServiceAccount
  name: admin-user
  namespace: kubernetes-dashboard
```

3- Now we should find the secret. Execute following command to get the secret:

```shell
kubectl get secrets
```
The result should be somthing like : 

| NAME | TYPE | DATA | AGE |
|--|--|--|--|
| default-token-dlgql | kubernetes.io/service-account-token | 3 | 37m |

4- Then, we need to find token we can use to log in. Execute following command to describe the secret:

```shell
kubectl describe secret default-token-dlgql
```

It should print something like:

```
eyJhbGciOiJSUzI1NiIsImtpZCI6IkxVUlgzZVRwUkRQMHpOX25YWnZWRS1BUGIzR2hYZ3AwUlhWWEFJUXBfQTgifQ.eyJpc3MiOiJrdWJlcm5ldGVzL3NlcnZpY2VhY2NvdW50Iiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9uYW1lc3BhY2UiOiJkZWZhdWx0Iiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9zZWNyZXQubmFtZSI6ImRlZmF1bHQtdG9rZW4tZGxncWwiLCJrdWJlcm5ldGVzLmlvL3NlcnZpY2VhY2NvdW50L3NlcnZpY2UtYWNjb3VudC5uYW1lIjoiZGVmYXVsdCIsImt1YmVybmV0ZXMuaW8vc2VydmljZWFjY291bnQvc2VydmljZS1hY2NvdW50LnVpZCI6Ijg5NzU3YWJhLTkyMTEtNDAyMC1iNmI4LTkyNzllOTUzZTM3YSIsInN1YiI6InN5c3RlbTpzZXJ2aWNlYWNjb3VudDpkZWZhdWx0OmRlZmF1bHQifQ.AZG2ftPsjWXwIdkSmfyutgbwAWNjUuoyOcUNqC1HxpKFOA2s3oGna_y-N-l5m7jEExmg9oX1NWXEevAsR1uTc3SbC44whP_JoWPuZuM3N0CI1IJh3sPExnLz6RmW2ImaQ9PN_1pDM9s_ZjLM2ryOHQxBjEzVNwDEHo5SS8qFTFKZkLwhp0S8DfZMCPamAuTRF5zYvFPX2a1EadIuy6_ug7-1V1UW9BtIrzsDYMTLN3WhrvvzXZFbzJPaVUqhAae5DVm-aofrEuYL-iRBbKZ9vmpl3SC1qOl7P7yPm_hNOFNdV19JOvPvYWKWrHvojJnkFNOv62QeOoqkQRXEXv0aAA
```

Copy the token.

5- You can enable access to the Dashboard using the kubectl `command-line` tool, by running the following command:
```bash

kubectl proxy
```
6- Kubectl will make Dashboard available at [http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/](http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/).

7- Now paste the token into `Enter token` field on the login screen.


###### More information :

[Kubernetes Concepts](https://kubernetes.io/docs/concepts/)

[Deploy on Kubernetes](https://docs.docker.com/desktop/kubernetes/)

[Kubernetes on Windows](https://docs.microsoft.com/en-us/virtualization/windowscontainers/kubernetes/getting-started-kubernetes-windows)

[Install and Set Up kubectl on Windows](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)

[Deploy and Access the Kubernetes Dashboard](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/)

[Adding Windows nodes](https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/adding-windows-nodes/)

[Kubernetes Cluster On Windows Server Worker Nodes](https://www.hostafrica.co.za/blog/new-technologies/install-kubernetes-cluster-windows-server-worker-nodes)

[Windows containers on Azure Kubernetes](https://docs.microsoft.com/en-us/azure/aks/windows-container-cli)

[Kubernetes on AWS](https://aws.amazon.com/kubernetes/)

[Google Kubernetes Engine](https://cloud.google.com/kubernetes-engine)

[Windows containers in Kubernetes](https://kubernetes.io/docs/setup/production-environment/windows/intro-windows-in-kubernetes/)

[Guide for scheduling Windows containers in Kubernetes](https://kubernetes.io/docs/setup/production-environment/windows/user-guide-windows-containers/)

[kubectl Cheat Sheet](https://kubernetes.io/docs/reference/kubectl/cheatsheet/)

## Datbase : SQL Server (Always on)

1- To create `Persistent Volume Claim` copy the following commands to new manifest file like `local-mssql-pvc.yaml` and use `kubectl apply -f local-mssql-pvc.yaml` command to create them.

```yaml
kind: PersistentVolumeClaim
apiVersion: v1
metadata:
  name: mssql2019-claim
spec:
  accessModes:
    - ReadWriteMany
  resources:
    requests:
      storage: 400Mi
```

To see kubernetes PersistentVolumeClaims:
 ```bash
kubectl get PersistentVolumeClaim

Or

kubectl get pvc

```

To see kubernetes storageclasses:
 ```bash
kubectl get storageclass

```

2- To create a secret in Kubernetes `mssql2019` mssql that holds the value `P@$$w0rd` for the `SA_MSSQL2019_PASSWORD`, run the command:
```bash
kubectl create secret generic mssql2019 --from-literal=SA_MSSQL2019_PASSWORD="P@$$w0rd"
```
**IMPORTANT** Replace `P@$$w0rd` with a complex password.

3- To create `Deployment` for `mssql2019 and clusterip and access it from your windows` copy the following commands to new manifest file like `mssql-plat-depl.yaml` and use `kubectl apply -f mssql-plat-depl.yaml` command to create them.

```yaml
kind: Deployment
apiVersion: apps/v1
metadata:
  name: mssql2019-depl
spec:
  replicas: 1
  selector:
    matchLabels:
      app: mssql
  template:
    metadata:
      labels:
        app: mssql
    spec:
      containers:
        - name: mssql
          image: mcr.microsoft.com/mssql/server:2019-latest
          ports:
            - containerPort: 1433
          env:
          - name: MSSQL_PID
            value: "Express"
          - name: ACCEPT_EULA
            value: "Y"
          - name: SA_PASSWORD
            valueFrom:
              secretKeyRef:
                name: mssql2019
                key: SA_MSSQL2019_PASSWORD
          volumeMounts:
          - mountPath: /var/opt/mssql/data
            name: mssqldb
      volumes:
      - name: mssqldb
        persistentVolumeClaim:
          claimName: mssql2019-claim
---
kind: Service
apiVersion: v1
metadata:
  name: mssql2019-clusterip-srv
spec:
  type: ClusterIP
  selector:
    app: mssql
  ports:
  - name: mssql
    protocol: TCP
    port: 1433
    targetPort: 1433
---
kind: Service
apiVersion: v1
metadata:
  name: mssql2019-loadbalancer
spec:
  type: LoadBalancer
  selector:
    app: mssql
  ports:
  - protocol: TCP
    port: 1433
    targetPort: 1433
```

**IMPORTANT** Stop MSSQL on your machine, if you want to connect via SQL Server Management Studio


#### More information:
[Kubernetes Storage Volumes](https://kubernetes.io/docs/concepts/storage/volumes/)

[Create a PersistentVolume](https://kubernetes.io/docs/tasks/configure-pod-container/configure-persistent-volume-storage/#create-a-persistentvolume)

[Create a PersistentVolumeClaim](https://kubernetes.io/docs/tasks/configure-pod-container/configure-persistent-volume-storage/#create-a-persistentvolumeclaim)

[Persistent Storage design document](https://github.com/kubernetes/community/blob/master/contributors/design-proposals/storage/persistent-storage.md)

[Deploy a SQL Server container in Kubernetes](https://docs.microsoft.com/en-us/sql/linux/tutorial-sql-server-containers-kubernetes?view=sql-server-ver15)

## Deploy RabbitMQ on Kubernetes
To create `Deployment` for `RabbitMQ` copy the following commands to new manifest file like `rabbitmq-depl.yaml` and use `kubectl apply -f rabbitmq-depl.yaml` command to create it.

```yaml
kind: Deployment
apiVersion: apps/v1
metadata:
  name: rabbitmq-depl
spec:
  replicas: 1
  selector:
    matchLabels:
      app: rabbitmq
  template:
    metadata:
      labels:
        app: rabbitmq
    spec:
      containers:
        - name: rabbitmq
          image: rabbitmq:3-management
          ports:
            - containerPort: 15672
              name: rbmq-mgmt-port
            - containerPort: 5672
              name: rbmq-msg-port
---
kind: Service
apiVersion: v1
metadata:
  name: rabbitmq-clusterip-srv
spec:
  type: ClusterIP
  selector:
    app: rabbitmq
  ports:
  - name: rbmq-mgmt-port
    protocol: TCP
    port: 15672
    targetPort: 15672
  - name: rbmq-msg-port
    protocol: TCP
    port: 5672
    targetPort: 5672
---
kind: Service
apiVersion: v1
metadata:
  name: rabbitmq-loadbalancer
spec:
  type: LoadBalancer
  selector:
    app: rabbitmq
  ports:
  - name: rbmq-mgmt-port
    protocol: TCP
    port: 15672
    targetPort: 15672
  - name: rbmq-msg-port
    protocol: TCP
    port: 5672
    targetPort: 5672
```

#### More information : 
[Kubernetes, Give Me a Queue](https://tanzu.vmware.com/content/rabbitmq/kubernetes-tanzu-rabbitmq)

[Deploying RabbitMQ to Kubernetes](https://blog.rabbitmq.com/posts/2020/08/deploying-rabbitmq-to-kubernetes-whats-involved/)

[RabbitMQ Cluster Operator for Kubernetes](https://www.rabbitmq.com/kubernetes/operator/operator-overview.html)

[RabbitMQ Cluster Kubernetes Operator Quickstart](https://www.rabbitmq.com/kubernetes/operator/quickstart-operator.html)

[Installing RabbitMQ Cluster Operator in a Kubernetes Cluster](https://www.rabbitmq.com/kubernetes/operator/install-operator.html)

## Traffic routing : NGINX Ingress Controller

1- To install `NGINX Ingress Controller` on kubernetes, just run the following command:
```bash
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.0.3/deploy/static/provider/cloud/deploy.yaml

```
To see kubernetes namespaces:
 ```bash
kubectl get namespaces

```

To see kubernetes Ingress pods:
 ```bash
kubectl get pods --namespace=ingress-nginx

```

To see kubernetes Ingress services:
 ```bash
kubectl get services --namespace=ingress-nginx

```

2- Ingress-nginx could route traffic to 2 different HTTP backend services based on the path name. To achieve this, copy the following commands to new manifest file like `ingress-srv.yaml` and use `kubectl apply -f ingress-srv.yaml`.

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: ingress-srv
  annotations:
    kubernetes.io/ingress.class: nginx
    nginx.ingress.kubernetes.io/use-regex: 'true'
spec:
  rules:
    - host: "etc.example.com"
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: easytemplatecore-clusterip-srv
                port:
                  number: 80
    - host: "www.example.com"
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: lateralapp-clusterip-srv
                port:
                  number: 80
```

### Edit Your Hosts File on Windows to route example.com
1- Open up the Host file using Notepad:
```
c:\windows\system32\drivers\etc\hosts
```
2- Add this line at the end of the file:
```
127.0.0.1 example.com
```
**IMPORTANT** Stop IIS on your machine to see example.com


###### More information :
[Services, Load Balancing, and Networking on Ingress](https://kubernetes.io/docs/concepts/services-networking/ingress/)

[NGINX Ingress Controller Installation Guide](https://kubernetes.github.io/ingress-nginx/deploy/)

[NGINX Ingress Controller Basic usage - host based routing](https://kubernetes.github.io/ingress-nginx/user-guide/basic-usage/)

[How to Edit Your Hosts File on Windows, Mac, or Linux](https://www.howtogeek.com/howto/27350/beginner-geek-how-to-edit-your-hosts-file/)

## RPC framework : GRPC

1-In Server App install package (EasyTemplateCore in this example):
``` bash
Install-Package Grpc.AspNetCore
```

2- Install this packages In client app (LateralApp in this example):

``` bash
Install-Package Grpc.Net.Client

Install-Package Google.Protobuf

Install-Package Grpc.Tools

```

#### More information:

[gRPC](https://grpc.io/)

[gRPC Quick start](https://grpc.io/docs/languages/csharp/quickstart/)

[Tutorial: Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start)

[Create Protobuf messages for .NET apps](https://docs.microsoft.com/en-us/aspnet/core/grpc/protobuf)

[Versioning gRPC services](https://docs.microsoft.com/en-us/aspnet/core/grpc/versioning)

[protocol-buffers Style Guide](https://developers.google.com/protocol-buffers/docs/style)

[Troubleshoot gRPC on .NET Core](https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-5.0)

[gRPC on .NET supported platforms](https://docs.microsoft.com/en-us/aspnet/core/grpc/supported-platforms)

[Use gRPC in browser apps](https://docs.microsoft.com/en-us/aspnet/core/grpc/browser)

[gRPC services with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/grpc/aspnetcore)

[Publish two different endpoints on Kestrel for two different endpoints on ASP.NET Core](https://stackoverflow.com/questions/57273862/publish-two-different-endpoints-on-kestrel-for-two-different-endpoints-on-asp-ne)

[Getting Started with ASP.NET Core and gRPC](https://blog.jetbrains.com/dotnet/2021/07/19/getting-started-with-asp-net-core-and-grpc/)

[Kestrel web server implementation in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel)

## Sysnch Consume APIs : HTTP Client

#### More information : 
[Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/learn/modules/build-web-api-aspnet-core/)

## Message broker : RabbitMQ

#### More information:

[RabbitMQ Tutorials](https://www.rabbitmq.com/getstarted.html)

## Datbase : PostgreSql

## Datbase : MongoDb

## Distributed Cache : Redis
1-Copy the following commands to new manifest file like `redis-config.yaml` and use `kubectl apply -f redis-config.yaml`.
``` yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: etc-redis-config
data:
  redis-config: |
    maxmemory 200mb
    maxmemory-policy allkeys-lru
```
2-Copy the following commands to new manifest file like `redis-depl.yaml` and use `kubectl apply -f redis-depl.yaml`.
``` yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: redis-depl
spec:
  replicas: 1
  selector:
    matchLabels:
      app: redis
  template:
    metadata:
      labels:
        app: redis
    spec:
      containers:
      - name: redis
        image: redis:6.2.6
        command:
          - redis-server
          - "/redis-master/redis.conf"
        env:
        - name: MASTER
          value: "true"
        ports:
        - containerPort: 6379
        resources:
          limits:
            cpu: "0.1"
        volumeMounts:
        - mountPath: /redis-master-data
          name: data
        - mountPath: /redis-master
          name: config
      volumes:
        - name: data
          emptyDir: {}
        - name: config
          configMap:
            name: etc-redis-config
            items:
            - key: redis-config
              path: redis.conf
---
kind: Service
apiVersion: v1
metadata:
  name: redis-clusterip-srv
spec:
  type: ClusterIP
  selector:
    app: redis
  ports:
  - name: redis
    protocol: TCP
    port: 6379
    targetPort: 6379
---
kind: Service
apiVersion: v1
metadata:
  name: redis-loadbalancer
spec:
  type: LoadBalancer
  selector:
    app: redis
  ports:
  - protocol: TCP
    port: 6379
    targetPort: 6379
```

#### More information : 

[Distributed caching in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/distributed)

[Redis Enterprise Software on Kubernetes](https://docs.redis.com/latest/kubernetes/)

[Configuring Redis using a ConfigMap](https://kubernetes.io/docs/tutorials/configuration/configure-redis-using-configmap/)

[Redis cluster tutorial](https://redis.io/topics/cluster-tutorial)

[Deploy Redis Enterprise Software on Kubernetes](https://docs.redis.com/latest/kubernetes/deployment/quick-start/)

## TODO : HybridCachingProvider : EasyCaching

HybridCachingProvider will combine local caching and distributed caching together.

The most important problem that this caching provider solves is that it keeps the newest local cached value.

When we modify a cached value, the provider will send a message to 'EasyCaching' Bus so that it can notify other Apps to remove the old value.

The following image shows how it runs.

![Hybrid Caching overview](https://raw.githubusercontent.com/dotnetcore/EasyCaching/master/media/hybrid_details.png)


1. Install the packages via Nuget

```bash
Install-Package EasyCaching.HybridCache
Install-Package EasyCaching.InMemory
Install-Package EasyCaching.Redis
Install-Package EasyCaching.Bus.Redis
```
2. Config in Startup class

```csharp
public class Startup
{
    //...

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddEasyCaching(option =>
        {
            // local
            option.UseInMemory("m1");
            // distributed
            option.UseRedis(config =>
            {
                config.DBConfig.Endpoints.Add(new Core.Configurations.ServerEndPoint("127.0.0.1", 6379));
                config.DBConfig.Database = 5;
            }, "myredis");

            // combine local and distributed
            option.UseHybrid(config =>
            {
                config.TopicName = "test-topic";
                config.EnableLogging = false;

                // specify the local cache provider name after v0.5.4
                config.LocalCacheProviderName = "m1";
                // specify the distributed cache provider name after v0.5.4
                config.DistributedCacheProviderName = "myredis";
            })
            // use redis bus
            .WithRedisBus(busConf => 
            {
                busConf.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6380));
            });
        });
    }
}
```

3. Call IHybridCachingProvider

Following code shows how to use EasyCachingProvider in ASP.NET Core Web API.

```csharp
[Route("api/[controller]")]
public class ValuesController : Controller
{
    private readonly IHybridCachingProvider _provider;

    public ValuesController(IHybridCachingProvider provider)
    {
        this._provider = provider;
    }

    [HttpGet]
    public string Get()
    {
        //Set
        _provider.Set("demo", "123", TimeSpan.FromMinutes(1));

        //others
        //...
    }
}
```
#### More information : 

[EasyCaching](https://github.com/dotnetcore/EasyCaching)

[What is HybridCaching](https://easycaching.readthedocs.io/en/latest/Hybrid/)

## Command and Query : CQRS

## search and analytics engine : Elasticsearch

## IDL - Describing REST APIs : Swagger

#### More information : 

[ASP.NET Core web API documentation with Swagger / OpenAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)

## Deploy EasyTemplateCore on Kubernetes

To create `Deployment` for `EasyTemplateCore` copy the following commands to new manifest file like `easytemplatecore-depl.yaml` and use `kubectl apply -f easytemplatecore-depl.yaml` command to create it.

```yaml
kind: Deployment
apiVersion: apps/v1
metadata:
  name: easytemplatecore-depl
spec:
  replicas: 3
  selector:
    matchLabels:
      app: easytemplatecore
  template:
    metadata:
      labels:
        app: easytemplatecore
    spec:
      containers:
        - name: easytemplatecore
          image: mohsen01/easytemplatecore:latest
---
kind: Service
apiVersion: v1
metadata:
  name: easytemplatecore-clusterip-srv
spec:
  type: ClusterIP
  selector:
    app: easytemplatecore
  ports:
  - name: easytemplatecore
    protocol: TCP
    port: 80
    targetPort: 80
  - name: easytemplatecoregrpc
    protocol: TCP
    port: 6000
    targetPort: 6000
```

#### More information : 
[Build ASP.NET Core applications deployed as Linux containers into an AKS/Kubernetes orchestrator](https://docs.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/build-aspnet-core-applications-linux-containers-aks-kubernetes)

## Deploy LateralApp on Kubernetes
To create `Deployment` for `LateralApp` copy the following commands to new manifest file like `lateralapp-depl.yaml` and use `kubectl apply -f lateralapp-depl.yaml` command to create it.

```yaml
kind: Deployment
apiVersion: apps/v1
metadata:
  name: lateralapp-depl
spec:
  replicas: 1
  selector:
    matchLabels:
      app: lateralapp
  template:
    metadata:
      labels:
        app: lateralapp
    spec:
      containers:
        - name: lateralapp
          image: mohsen01/lateralapp:latest
---
kind: Service
apiVersion: v1
metadata:
  name: lateralapp-clusterip-srv
spec:
  type: ClusterIP
  selector:
    app: lateralapp
  ports:
  - name: lateralapp
    protocol: TCP
    port: 80
    targetPort: 80 
```

## UnitTest : NUnit


#### More information : 

[NUnit Documentation Site](https://docs.nunit.org/index.html)

[moq - mocking library](https://github.com/moq/moq4)

[Coverlet - code coverage](https://github.com/coverlet-coverage/coverlet)

[Unit test](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing)

[FluentAssertions](https://github.com/fluentassertions/fluentassertions)

## Integrated Test : xUnit

#### More information : 

[Integration tests in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests)

## Test API : Postman

## CI/CD : github Actions

-Build & Test & Artifact

```yaml
name: ASP.NET Core CI

on:
  push:
    branches: [ master ]
    paths-ignore:
      - 'readme.md'
  pull_request:
    branches: [ master ]
    paths-ignore:
      - 'readme.md'

jobs:
  build_and_test:
    if: contains(toJson(github.event.commits), '[SKIP CI]') == false
    runs-on: ubuntu-latest
        
    steps:
    - name: Dump GitHub Context
      env:
        GITHUB_CONTEXT: ${{ toJson(github) }}
      run: echo "$GITHUB_CONTEXT"
      
    - uses: actions/checkout@v2
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 5.0.x
    - name: where are we
      run: pwd
    - name: list some key files
      run: ls
    - name: Restore dependencies
      run: dotnet restore ./framework/
    - name: Build
      run: dotnet build --no-restore ./framework/ --configuration Release
    - name: Test
      run: dotnet test --no-build --verbosity normal ./framework/ --configuration Release
      
    - name: Upload Artifact
      uses: actions/upload-artifact@v2
      with:
        name: EasyTemplateCore
        path: ./framework/src/EasyTemplateCore.Web/bin/Release
```

#### More information : 

[checkout](https://github.com/actions/checkout)

[setup-dotnet](https://github.com/actions/setup-dotnet)

[upload-artifact](https://github.com/actions/upload-artifact)

## Image repository : Docker hub

#### More information : 

[Configure GitHub Actions to build Dockerfile](https://docs.docker.com/ci-cd/github-actions/)

[Using environments for deployment](https://docs.github.com/en/actions/deployment/using-environments-for-deployment)

[How to use environment secret on github action?](https://github.com/actions/starter-workflows/issues/785)

[Events that trigger workflows](https://docs.github.com/en/actions/learn-github-actions/events-that-trigger-workflows)

[Publishing Docker images](https://docs.github.com/en/actions/publishing-packages/publishing-docker-images)


## Cloud Services : AWS

#### More information : 

[Deploying to Amazon Elastic Container Service](https://docs.github.com/en/actions/deployment/deploying-to-amazon-elastic-container-service)

## License

[MIT](https://choosealicense.com/licenses/mit/)