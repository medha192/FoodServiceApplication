#Food Service Application

#High Level Overview: 
Food service application allows users to place order and get acknowledgement back asynchronously. The order placed is sent to another server which process the order.

- This application is comprised of four main components : client application , publish events, process events and subscribe events

Clinet Application - FoodService.MVC is a client application responsible for taking input from user and calling the FoodOrderService.API via proxy 

Publish event - FoodOrderService.API is responsible for taking the order and initialting the publish event 

Process Event - RabbitMQ takes the events and process the event created

Subscribe Event - FoodProcessService.API subscribes to the event created by FoodOrderService.API and fetches the events from the queue and stores it in database. 

# Database
- Microsoft SQL serve
 - To connect to database change the connection string in appsettings.json
 - Run the initital migration and update the database
 - To add migration, go to package manager console and type 'Add-Migration <Migration Name>'
 - To update database, go to package manager console and type 'Update-Database'
 For more information on migration please refer "https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs"
# end
 
# Queue broker
- Rabbit Mq 
- You need to have rabbitmq up and running for this application
- This application is using local host as server.
- To install the rabbitmq pleas refer to  "https://www.rabbitmq.com/dotnet.html"
#end

# Design Pattern 
- Mediator 
- Mediator pattern is used to reduce communication complexity between multiple objects or classes
#end

# Metrics and tracing
- For Metric and tracing using Prometheus 
- Ports are currently hard coded currently, before running application configure the port pointing to correct environment and run the Prometheus before running application
- make sure you configure Prometheus in rabbitmq for tracing rabbitmq. For more info on how to set it up please refer to https://www.rabbitmq.com/prometheus.html
#end

# Framework and Library Used
- RabbitMQ Client
- MediatoR
- EntityFramework
- Dependency Injection
#end

# Running Application
- FoodService.MVC is configured to run on https://localhost:5005;http://localhost:5004
- PlaceOrderService.Api is configured to run on https://localhost:5001;http://localhost:5000
- ProcessOrderService.Api is configured to run on https://localhost:5003;http://localhost5002:
- Make sure Rabbitmq is up and running and run the application as multiple start up projects in visual studio to run the application simulatenously
- Make sure RoodService.MVC is pointing to right url of PlaceOrderService.Api in appsettings
#end

# Few additional enhancements but not limited to below points
- Writing docker compose yml file for running multiple microservices simulatenously
- Having some sort of service discovery to dicover mutiple services like 'Consul'
- Having identity provider like 'Ocelot' or Azure IAM
- Use Grafana with Promotheus for vizualization 
- Setting up alert manager with promotheus if service is down 
- Getting acknowledgement back to client when order is processed 
#end
