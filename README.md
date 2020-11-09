#Food Service Application

#High Level Overview: 
Food service application allows users to place order and get acknowledgement back asynchronously. The order placed is sent to another server which process the order.

- This application is comprised of three main components : publish events, process events and subscribe events

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

#Queue broker
- Rabbit Mq 
- You need to have rabbitmq up and running for this application
- This application is using local host as server.
- To install the rabbitmq pleas refer to  "https://www.rabbitmq.com/dotnet.html"


#Design Pattern 
- Mediator 
- Mediator pattern is used to reduce communication complexity between multiple objects or classes


#Framework and Library Used
- RabbitMQ Client
- MediatoR
- EntityFramework
- Dependency Injection

#Running Application
- PlaceOrderService.Api is configured to run on https://localhost:5001;http://localhost:5001
- ProcessOrderService.Api is configured to run on https://localhost:5003;http://localhost:
- Make sure Rabbitmq is up and running and run the application as multiple start up projects in visual studio to run the application simulatenously
#end
