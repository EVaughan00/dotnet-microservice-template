# Dotnet microservice template

## Structure 

https://hackernoon.com/hn-images/1*YVxaXqiIYskqPauNKZ2OSA.png

## Usage

Install the microservice as a dotnet template using:

dotnet new -i ./

Create a new microservice using:

dotnet new microservice -n Identity

This will change all "Template" tags in the microservice to "Identity".

## Application boilerplate

This template is best used with the application-boilerplate structure. The boilerplate contains
all dependency paths as well as an API Gateway for microservices placed in the 'Services' directory.
Docker-compose is used to spin up, microservices, databases, and the API Gateway.
