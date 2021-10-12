# P2_TheTofuWarriors
Project 2 for Group 1: The tofu warriors

## Project Description
Tofu Warriors is a search engine and collaborative forum for gourmet recipes. Users are able to securely login and then search, create, edit, and clone recipes. Recipes are available to users from either the 3rd party API or from user-created recipes stored in our database. The comment section allows for users to express their opinions on recipes that they tried, suggest improvements on recipes, and interact with other foodies by responding directly to their comments. Each recipe has an ingredient list, instructions on how to prepare the meal, and a list of tags to describe what kind of recipe it is. This application challenges users' culinary creativity and provides them with the information and community to be able to create amazing meals.

## Technologies Used
- Azure Devops (Pipelines + Boards)
- ASP.NET Core Web API
- Entity Framework Core
- HTML
- CSS
- Typescript
- Angular 2+
- Jasmine
- Karma
- xUnit Testing
- Sql Server
- C#
- REST
- SQL
- Visual Studio
- Swagger
- Git
- Agile-Scrum
- Azure SQL Databases
- Azure Web App PaaS

## Features
Current features:
- Search Edamam recipe API using keywords and metadata tags
- Create and Edit your own recipes, as well as clone recipes from other users
- Comment threads for recipes to provide feedback and interact with other users
- Follow and unfollow other users
Future additions:
- Add display to home page to show recent activity of users you follow
- Add ability for users to create recipe from results of Edamam's API search
- Add ratings to recipes so users can get an idea of how popular a recipe is

## Getting Started
First, clone this repository
> git clone https://github.com/08162021-dotnet-uta/P2_TheTofuWarriors.git

Next, prepare a database to develop against using our creation and seed scripts [here](https://github.com/08162021-dotnet-uta/P2_TheTofuWarriors/tree/main/SQL_Scripts)
> run the DDL script first, followed by the DB_Seed script.

Set up the connection string for your database using the user secrets for ASP.NET projects [(docs)](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)

Conigure the appsettings.json file to use the correct domain and endpoints for your environment. If developing on localhost, the current configuration should work as-is.

## Usage
Execute the command to start the ASP.NET Web API project (paths given from repo base folder):
> cd TheTofuWarriors/TofuWarrior
> dotnet run

Next, transpile and serve the Angular front end project (paths given from repo base folder):
> cd tofu-warriors-ui
> ng serve --open

Make sure your browser navigates to the /index.html page. You are now interacting with the TofuWarriors recipe website!

## Contributors
Naima Jackson
Casey Peng
Jonathan Bukowsky
Akil Tomlinson

## License
The TofuWarriors Recipe project uses the [MIT License](https://github.com/08162021-dotnet-uta/P2_TheTofuWarriors/blob/main/LICENSE)
