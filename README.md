# MovieBuff

This is the backend repository for a movie rating app - MovieBuff similair to IMDB but much simpler. Main technology used for backend development is .NET 5.

## Setup instructions

1. Clone this repository to your local machine
2. Make sure you have SQL Server set up. If you own a database with the name **moviebuff-db** then make sure to change the name of this project's databse by going to **appsettings.json** and changing the **ConnectionStrings'** **DefaultConnection** value.
3. run `dotnet ef database update` in the terminal to create the database
4. run `dotnet watch run -p MovieBuff.Web` to start the web api

**Important note**: Make sure that the corresponding [Frontend App](https://github.com/farisde/JAP_Task_1_FE/) is run on **https://localhost:3000** for all requests to work. If that is not the case on your local machine, then you will need to update the **Default CORS policy** in **ConfigureServices** method of the **Startup.cs** class.

## Functionalities

- REST API
- Routes for searching movies, getting all movies from the database, rating movies and user register and login
- OAUTH2 implemented using JWT access token format
