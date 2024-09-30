Build real world e-commerce application using ASP.NET Core MVC, Entity Framework Core and ASP.NET Core Identity.

<<<<<<< HEAD
Dependency Injection Service Lifetimes

*** Transient - New Service is created for every request
*** Scoped - New Service is created once per request
*** Singleton - New Service is created once per application lifetime
=======
<h3>Dependency Injection Service Lifetimes</h3>
* Transient - New Service- every time requested *
* Scoped - New Service- once per request *
* Singleton - New Service- once per application lifetime *

<h3>Repository Pattern </h3>
<p>The Repository Pattern is a design pattern commonly used in ASP.NET applications to abstract data access logic from the business logic. It acts as a middle layer between the application's business logic and data access layers, providing a clean and centralized way to manage data interactions, typically with databases. The Repository Pattern helps organize code, promote testability, and decouple the business layer from the data access layer.

Key Concepts of the Repository Pattern:
Abstraction of Data Access Logic:

The Repository Pattern abstracts the interaction with the underlying data source, such as databases. 
It provides methods for retrieving, adding, updating, or deleting data without exposing the complexity of 
data access operations to the business logic.
Encapsulation of Queries:

All data access logic, including SQL queries or calls to Entity Framework (EF), is encapsulated within the repository. This means that the service layer or controller interacts only with methods defined by the repository, making the code easier to read, maintain, and modify.
Separation of Concerns:

The Repository Pattern separates business logic from data access logic, adhering to the Single Responsibility Principle. This means that changes to the data source or the way data is retrieved only affect the repository layer, leaving the business logic untouched.
Testability:

Since the data access logic is abstracted, it is easier to unit test the business logic by mocking the repository. This makes the application more testable, particularly when using dependency injection to provide repository instances.</p>
>>>>>>> develop
