## Dotnet microservice template

Install the microservice as a dotnet template using:

dotnet new -i ./

Create a new microservice using:

dotnet new microservice -n Identity

This will change all "Template" tags in the microservice to "Identity".

This template is best used with the application-boilerplate structure. The boilerplate will contain 
all dependency paths as well as an API Gateway for microservices placed in the 'Services' directory.
Docker-compose is used to spin up, microservices, and databases, and the API Gateway.
