# POS

Welcome to Pizza Ordering System. Order your pizza and enjoy :)

## Tools Requirements

- Visual Studio 2022
- .NET 6
- MS SQL Server
- Angular 15

## Steps to run application

1. Open POS.API
2. Run API
3. Goto POS.UI
4. Run command `npm start`

## Database setup

1. Correct conncetion string appSettings.Json of POS.API.
    `"POSConnStr": "Data Source=.;Initial Catalog=POSDb;Integrated Security=true;"`
2. Run migration using EF core `update-database`
3. Seed Data for inventory from script `SeedingScript.sql`

## Technology stack

### For the development of API following technologies are used

- .NET 6
- ASP.NET Core
- Entity Framework core
- NLog
- Fluent Validation
- MediatR & CQRS
- Swagger

#### For Unit testing below technologies are used

- xUnit
- FakeItEasy
- Shouldly

#### For static code analysis SONAR Cloud is integrated with github action
