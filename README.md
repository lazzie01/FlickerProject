# FlickerProject
This project consists of five seperate projects. It main purpose is to aggregates images and metadata of images from various external sources, 
it uses Flickr (https://www.flickr.com/).
    The project helps uses to find landmarks around a location, for instance if a user search for a location called Harare (https://en.wikipedia.org/wiki/Harare), the application
    will search for all places (landmarks) in Harare and their respective metadata. 

# API (.Net Core 3.1 Target Framework)
-> Web API project for the backend of the project, it depends on both the Business Layer and Data Layer

# Business Layer (.Net Core 3.1 Target Framework)
-> Layer for business logic, all the logic of the application reside in this layer. This layer depends on the Data Layer

# Data Layer (.Net Core 3.1 Target Framework)
-> Layer for project data entities, all database entities reside in this layer. The Data Layer makes use of Entity Framework Code First approach
   when generating database objects.

# FlickerAPI (.Net Framework 4.7.2 Target Framework)
-> Separate API for handling image location requests, this layer makes use of FlickerNet 3rd party library (https://www.nuget.org/packages/FlickrNet)

# Frontend (Angular 9 Framework)
-> Application UI/UX layer, this is the user presentation layer, which utilizes the API layer to perform all database related operations.

# Technology Stack
-> The application was developed using the following technologies

    database/datastore : SQL Server
    
    backend technology/framework :  .Net Core 3.1 Web API, Entity Framework Core 3, .Net Framework 4.7, C#
    
    UI technology/framework : Angular 9, Bootstrap 4, Html, CSS

# Debugging The Application

-> Step 1: Run the backend
    Open the Backend>System>FlickerProject.sln using Visual Studio
    
    Open the Web.config project in System Project and change the default connection string to point to your server.
    
    Run the application

-> Step 2: Run the frontend
    Open the FlickerProject-> Frontend-> my-app using Visual Studio Code and execute ng serve command
    
    The Frontend application will open in the default web browser, please wait for the application to create a database and seed it with inital data.
    
    The application will initially list two contact information of Lazarus Munetsi and Jaco Kotze
    
    Test the application by performing all the CRUD and search operations 

