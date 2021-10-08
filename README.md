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

2- To create sample user and a Service Account copy the following commands to new manifest file like `kube-dashboard-adminuser.yaml` and use `kubectl apply -f kube-dashboard-adminuser.yaml` to create them.

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

NAME                  TYPE                                  DATA   AGE
default-token-dlgql   kubernetes.io/service-account-token   3      37m

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

### NGINX Ingress Controller 

1- To install `NGINX Ingress Controller` on kubernetes, just run the following command:
```bash
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.0.3/deploy/static/provider/cloud/deploy.yaml

```

Just for information:

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

2- Ingress-nginx will route traffic to 2 different HTTP backend services based on the path name.To achieve this, copy the following commands to new manifest file like `ingress-srv.yaml` and use `kubectl apply -f ingress-srv.yaml`.

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
    - host: example.com
      http:
        paths:
          - path: /easytemplatecore/api/weather
            pathType: Prefix
            backend:
              service:
                name: easytemplatecore-clusterip-srv
                port:
                  number: 80
          - path: /lateralapp/api/weather
            pathType: Prefix
            backend:
              service:
                name: lateralapp-clusterip-srv
                port:
                  number: 80
```

### Edit Your Hosts File on Windows to rout example.com
1- Open up the Host file using Notepad:
```
c:\windows\system32\drivers\etc\hosts
```
2- Add this line at the end of the file:
```
127.0.0.1 example.com
```


###### More information :
[Deploy on Kubernetes](https://docs.docker.com/desktop/kubernetes/)

[Kubernetes on Windows](https://docs.microsoft.com/en-us/virtualization/windowscontainers/kubernetes/getting-started-kubernetes-windows)

[Install and Set Up kubectl on Windows](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)

[Deploy and Access the Kubernetes Dashboard](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/)

[Adding Windows nodes](https://kubernetes.io/docs/tasks/administer-cluster/kubeadm/adding-windows-nodes/)

[Kubernetes Cluster On Windows Server Worker Nodes](https://www.hostafrica.co.za/blog/new-technologies/install-kubernetes-cluster-windows-server-worker-nodes)

[Windows containers on Azure Kubernetes](https://docs.microsoft.com/en-us/azure/aks/windows-container-cli)

[Kubernetes on AWS](https://aws.amazon.com/kubernetes/)

[Google Kubernetes Engine](https://cloud.google.com/kubernetes-engine)

[NGINX Ingress Controller Installation Guide](https://kubernetes.github.io/ingress-nginx/deploy/)

[NGINX Ingress Controller Basic usage - host based routing](https://kubernetes.github.io/ingress-nginx/user-guide/basic-usage/)

[How to Edit Your Hosts File on Windows, Mac, or Linux](https://www.howtogeek.com/howto/27350/beginner-geek-how-to-edit-your-hosts-file/)

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