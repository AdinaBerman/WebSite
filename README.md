How to run this project:
The project can be run in Visual Studio 2022 or higher. In .NET 7. You have to work against a DB and that's how the DB will be created.


About the project:
This project represents a store selling various garden products.
Written in NET. 7, in the C# language. Client side is written in JS and HTML.
The project uses the architecture of the layers and communication between them by dependency injection in order to create the possibility of expanding the project in the future - scalability.
EF ORM is used.
The project was written using the DB FIRST method.
A documented swagger is installed for all functions in the controllers as well as the use of DTO for simplifying the objects and flattening them.
The flattening of the DTO objects was done by mapping the objects - using the AutoMapper.Extensions.Microsoft.DependencyInjection package
Writing to an active log in case of a malfunction and sending to email when necessary.
Saving sensitive data such as connection string in the appsetting file.
Use of middlewares in order to handle errors as well as to document browsing on the website.
