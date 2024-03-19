# Genre Generator App

A simple web scraper that scrapes the web for different music genre. This purpose of this project was to learn how to use helm charts with K8.

This readme would guide you on how to setup locally and also deploy the application on AWS.

# Pre-requisites
tools needed to run the application

1. .NET
2. Git
3. Docker
4. Minikube(locally)
5. Helm

## Clone Repo

Execute:

```git clone <repo-url>```



### Build & Run via docker

execute:

```cd Genre-App && bash build.sh```

1. Access Swagger doc at http://localhost:3000/swagger/index.html
2. Access API endpoint at http://localhost:3000/genre


### Publish Docker Image

execute

``` bash publish.sh 1.0 genre-app ```


### Deployment on minikube


Start Mimikube

```minikube start```

executing this script in the root directory of the project would create pods, services and deployments

```bash deploy.sh genre-release ./genre-charts Production```

get application endpoint

```minikube service --url genre-app-service```

Any url returned when you execute the command above can be used to access the API endpoint and the Swagger doc



### Deployment on AWS

To deploy on AWS, you'd have to use this [terraform configurations](https://github.com/FunbiOyede/terraform-projects) to setup your infrastructure. Remember to delete resources when you are done developing or testing 





