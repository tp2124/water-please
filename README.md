# water-please-server

Water Please is a service that will help to try and allow users to setup reminders about when to water their plants.

## Tech Stack
* DB: EFCore
* Web API: ASP.NET Core Web API (MFC)
  * This is using .NET Core 3.0 and the following features:
    * Dependency Injection
* Testing: NUnit
* CI/CD: GitHub Actions with the following coverage
  * Build and Test runs on all PR changes.
  * Packaging and Deployment to public NuGet on specific branch updates.
  * Proper branch enforcement for development.
* Documentation: Swagger + Swashbuckle

## Endpoint Documentation
This API utilizes Swagger to generate endpoint API documentation. With the API running, use the `/swagger/` page to access the endpoints for testing or learning.

## Notes
* Following [ASP.NET Core + EF Core Web API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code) tutorial for the initial implementation of the backend.
* Adding Swashbuckle (and Swagger) via this [tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.0&tabs=visual-studio-code).
