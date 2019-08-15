# Mvc-6-Seeding-Data

Just like MVC 5, I was trying to enable automatic migrations and Seeding default data, but it seems the behaviour has been changed in MVC 6, so I thought I'll share the tip.


Here, we'll try to learn Seeding data in MVC 6 ASP.NET Core 2.2 application. Here, mainly Seeding data only is part of our scope.

Using Visual Studio 2019, I created a .NET Core 2.2 web application using the default template. Now my requirement is to seed some default data when the database is being created with Entity framework migrations.

For that purpose, we'll create a class DbInitializer.cs in the project and call its Initialize function from Startup.cs class.

Check out for more details.
https://www.codeproject.com/Articles/5163367/Seeding-Data-MVC-6-NET-Core-Application
