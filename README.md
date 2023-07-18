# Repo: entity-framework-intro
Getting Started with Entity Framework.
Entity Framework Core is an Object-Relational Mapper that simplifies working with relational databases using strongly-typed .NET objects. Since .NET7 Microsoft is no more using "Core" so it's not about EF core 7 it's just about EF7. 

Please refer to my PDF files for more details and explanations 

# Repo Projects Sections
This repo contains x projects:
> EFGetStarted => For Getting Started with using EF and SQLite


# EFGetStarted Project
Using C# Console App to connect a SQLite Database which is a database that self-contained in a file. SQlite is an open source cross-platform embedded database technology. Refer to my PDF file "Entity Framework Essentials".


# Create the database: 
The following steps use migrations to create a database. Run the commands: 
> Add-Migration InitialCreate  
> Update-Database 

**These two commands do the following:** 
- The Add-Migration command => scaffolds a migration to create the initial set of tables for the model.  
- The Update-Database command => creates the database and applies the new migration to it. 

# Credits, References, and Resources:
- [Entity Framework documentation hub](https://learn.microsoft.com/en-us/ef/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/?WT.mc_id=EducationalEF-c9-niner)
- [Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio)
- [Quickly find and install a package](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell#quickly-find-and-install-a-package)
- [Database Providers](https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
- [Connection strings: Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings)
- [Connection Strings ASP.NET](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings)
- [Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://learn.microsoft.com/en-us/ef/core/cli/powershell#installing-the-tools)
- [Microsoft.NET](https://dotnet.microsoft.com/en-us/)
- [Cam Soper: Content Developer at Microsoft](https://github.com/CamSoper)
- [DB Browser for SQLite](https://sqlitebrowser.org/)


