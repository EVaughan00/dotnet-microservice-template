# Dotnet microservice template

## Structure 

https://www.google.com/url?sa=i&url=https%3A%2F%2Fhackernoon.com%2Fclean-domain-driven-design-in-10-minutes-6037a59c8b7b&psig=AOvVaw37wMZEH3_msXHE9Lmv0gVI&ust=1602427350067000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKCSoKGhquwCFQAAAAAdAAAAABAV

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
