using System.Collections.Generic;
using BlazorWebCV.Components.Projects;
using BlazorWebCV.Models;

namespace BlazorWebCV.Helpers;

public static class ProjectHelper
{
    public static List<ProjectModel> GetProjects()
    {
        List<ProjectModel> projects = new();
        projects.Add(new ProjectModel("BlazorIDB",
          "images/Projects/nuget.webp",
          "Coded in .Net 6, a nuget package for Blazor that utilizes IndexedDb.",
          "This is a simple wrapper of the idb-keyval.js library for Blazor applications. It is designed to be used similar to Entity Framework Database.",
          "https://github.com/Spylak/BlazorIDB",
          2));
        projects.Add(new ProjectModel("ProjectCamilla",
          "images/Projects/camilla.webp",
          "Coded in .Net Core with DevExtreme, DevExtreme Library, MVC Project with SQL Server Database.",
          "This is a project I was placed to in my first job.I was responsible for parts of it's maintenance as well as adding some features. It is an MVC project consisting of the main application, a WEB API app taking care of external calls and a worker app. It is written in .Net Core, JavaScript and jQuery along with DevExtreme library. In this project I gained experience on CI/CD, remote desktop functionalities, Azure DevOps and SQL Server Database.",
          "",
          8));
        projects.Add(new ProjectModel("ArduinoProject",
          "images/Projects/chip.webp",
          "Arduino IDE, Overwrote a fitness tracker chip.",
          "This was my first introduction to scrum-like schedule in professional ground, the goal of my project was to change the functionality of a Fitness Tracker board using Arduino IDE, changing the source code of a related project in order to validate and replicate it’s behavior, transforming it into an optical density device for liquids.",
          "",
          11));
        projects.Add(new ProjectModel("Botcraft",
          "images/Projects/discord.webp",
          "Coded in C# and key.NET, used Discord.Net Library",
          "A discord bot written in C# and .NET with APIs for Reddit, Youtube and Oxford Dictionary.",
          "https://github.com/MrSpyretos/Botcraft",
          5));
        projects.Add(new ProjectModel("Wolftrack",
          "images/Projects/footprint.webp",
          "Coded in .Net Core, Web API Project.",
          "A backend CRUD application with Geolocation API in .NET Core.",
          "https://github.com/MrSpyretos/Wolftrack",
          10));
        projects.Add(new ProjectModel("Gyxi",
          "images/Projects/gyxiLogo.png",
          "Coded in Blazor with MudBlazor, Blazor WebApp with token authentication and WebAPI integration.",
          "This is a C# .Net 6 Blazor WebAssembly app using MudBlazor and MVU architecture.",
          "",
          4));
        projects.Add(new ProjectModel("ThemingProject",
          "images/Projects/htmlcss.webp",
          "HTML and CSS, Static HTML page.",
          "This is a static page project that demonstrates Pixel Perfect UI/UX Design, given a set of images in Figma I had to replicate that in HTML and CSS.",
          "https://github.com/MrSpyretos/ThemingProject",
          9));
        projects.Add(new ProjectModel("ProjectLizzy",
          "images/Projects/lizzy.webp",
          "Coded in .Net Core with DevExtreme, DevExtreme Library, MVC Project with SQL Server Database.",
          "This ia a ticketing system with custom integration for AzDo for tracking and submission of tickets (requests, incidents etc.), creating tickets in the project results in creating the appropriate ticket category in Azure DevOps.",
          "",
          7));
        projects.Add(new ProjectModel( "ProjectCooking",
          "images/Projects/recipe.webp",
          "Coded in .Net Core and Blazor, Blazor WebAssebly, Web API and POSTGRESQL Database.",
          "This is a personal project I develop on my free time, at the moment it consists of 2 Libraries(one for the DTOs and one for the Database Entities), a front end application on Blazor WASM and a WEB API project that takes cares of the business logic with repository pattern JWT Authentication and 2FA via email, Custom Google SignIn and email verification as well as ASP.NET Identity, using MudBlazor library.",
          "",
          6));
        projects.Add(new ProjectModel("WeddingInvitation",
          "images/Projects/weddingInv.webp",
          "Coded in Blazor with MudBlazor, Blazor WebApp with API project and GoogleSheets as Database.",
          "This is a project that is meant to be used for wedding invitations in digital form. It consists of a web app in Blazor WebAssembly, an API in .Net 6 and as a database there is an integration google sheets API.It uses CI/CD through Github Actions and it is hosted in Azure, the API project as App Service and the client web app as Static Web App Service (since it's SPA).",
          "https://github.com/Spylak/WeddingInvitation",
          3));
        projects.Add(new ProjectModel("Karakoulak Tavern",
          "images/Projects/karakoulakPasta.webp",
          "SSR Astro.js for the front end, Strapi CMS for the backend and Postgresql as a Database docker Containers.",
          "This application is coded in Astro.js and used node server side rendering, deployed as a docker container in a Linux VPS on Linode, the CMS used was strapi with a Postgresql database all of them containerized and communicate with each other through docker bridge network and exposed with Nginx Server as a reverse proxy.",
          "https://github.com/Spylak/KarakoulakTavern",
          1));
        return projects;
    }
}