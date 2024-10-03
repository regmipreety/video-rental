Build real world e-commerce application using ASP.NET Core MVC, Entity Framework Core and ASP.NET Core Identity.

<h3>Dependency Injection Service Lifetimes</h3>
* Transient - New Service- every time requested 
* Scoped - New Service- once per request 
* Singleton - New Service- once per application lifetime 

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

Since the data access logic is abstracted, it is easier to unit test the business logic by mocking the repository. 
This makes the application more testable, particularly when using dependency injection to provide repository instances.</p>

<h3>Unit Of Work (UoW)</h3>
<p>The Unit of Work (UoW) is a design pattern used in software development to manage and coordinate changes across multiple repository objects during a business transaction, ensuring that all changes are committed or rolled back as a single unit. In the context of .NET (including .NET 8), the Unit of Work pattern works particularly well with Entity Framework (EF), as EF already implements many of the features needed for transaction management.

Unit of Work Overview
The Unit of Work pattern in .NET is a way of managing multiple repository changes under one transaction boundary, making sure that all data operations are performed in an atomic manner. The main objectives of the Unit of Work pattern are:

Maintain Consistency: By tracking changes across repositories, it can ensure that all changes are committed or rolled back together.
Minimize Database Access: The pattern delays changes to the database until everything is ready to be committed.
Transaction Management: Unit of Work coordinates the work of multiple repositories, managing commit and rollback functionality.
Key Components
Repositories: Each repository encapsulates logic for data operations on a particular entity.
Unit of Work Class: It manages the repositories and calls SaveChanges() in a single transaction when all operations are complete.</p>

<h3>Areas</h3>
<p>
Areas in ASP.NET are a feature that helps to organize large web applications into smaller, functional sections, making it easier to manage complexity and maintain separation of concerns. Each area is essentially a mini-MVC structure within an ASP.NET application, with its own controllers, views, and models. Areas are particularly useful for dividing application functionality logically, such as for different modules or sections like "Admin," "Customer," "Products," etc.

Key Features of Areas
Modular Structure: Each area contains its own set of controllers, views, and models, which helps to modularize the application into distinct sections.
Independent MVC Structures: An area has its own Controllers, Views, and optionally Models, similar to how the main MVC application is organized.
Routing: Areas have their own routes, which can help provide URLs that are specific to each part of the application. This also makes it easier to manage more complex routing configurations.
Common Use Cases
Admin vs. Customer Modules: For instance, an application may have an "Admin" area for managing the backend and a "Customer" area for users interacting with the frontend.
Feature Segmentation: Features like reports, products, or support can each be organized into separate areas to facilitate easier development and maintenance.
</p>
<table>
<tr>
<th>ViewBag</th>
<th>ViewData</th>
<th>TempData</th>
</tr>
<tr>
<td>
<p>
* ViewBag transfers data from the Controller to View, not vice-versa. Ideal situations in which the temporary data is not in a model.
* ViewBag is a dynamic property that takes advantage of the new dynamic features in C# 4.0. Any number of properties can be assigned to ViewBag.
* The ViewBag's life only lasts during the current http request. ViewBag values will be null if redirection occurs.

</p>
</td>
<td>
<p>
* ViewData transfers data from the Controller to View, not vice-versa. Ideal situations in which the temporary data is not in a model. It is derived from ViewDataDictionary which is a dictionary type.
* ViewData value must be type cast before use.
* The ViewData's life only lasts during the current http request. ViewData values will be null if redirection occurs.
</p>
</td>
<td>
<p>
* TempData can be used to store data between two consecutive requests.
* TempData internally use Session to the data, so think of it as a short lived session.
* TempData value must be type cast before use. Check for null values to avoid runtime error.
* TempData can be used to store only one time messages like error messages, validation messages.
</p>
</td>
</tr>
</table>
<h3>View Model</h3>
<p>
A View Model serves as a specialized object that contains only the data required by the view, helping to facililate the flow of information between controller and the view. 
Entities are designed to model the structure of the database, while View Models are tailored to the specific needs of the view. It helps to implement the single responsibility in the SOLID principle.
</p>