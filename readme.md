# Education Management System | .Net core 6 (VS 2022) + Angular v14 + Node.JS with NPM + SQL server 2012/2018/2022



## Features

- Course Management 
- Grade Management 
- Subject Management etc


## Tech Stack

**Client:** Angular v14  + Node.JS with NPM

**Server:** .Net Core v6.0 (VS 2022)

**DataBase:** SQL Server

## First open the solution file name (EducationManagementSystem.sln)

## you need to install few packges in both projects (API & UI) before going to run entire system

 1. Education.API project (APIs)

     * Install few packages from Nuget packages below

    -- Microsoft.EntityFrameworkCore
    -- Microsoft.EntityFrameworkCore.Tools (for migration)
    -- Microsoft.EntityFrameworkCore.SqlServer
  
    * Please make changes the ConnectionStrings as per your db in appsettings.json

    * Run entity framework migration to create new database (tools>nuGet Package Manager>Package Manager Console)

     *Note : please delete the Migrations forlder, becouse it will be created again, once run the migration command     given below

    -- command : add-migration and enter key
    -- Name : intitial enter key
    -- command : update-datebase enter key

  2 . EMSUI project (App)

  Please install few packages in App project
   First set the app path via CD command
   --- local solution path> cd EMSUI/UI enter key
   -- CLI (npm install -g @angular/cli) 

  
*** Instalation almost completed, now time to run the app  
   * please run the Education.API first, once run, you are able to see all API's displayed in Swagger (testing tool)

 ## steps to run the client app  (View>Terminal>Developer Command Prompt)

 -- local solution path> cd EMSUI/UI enter key
 -- ng serve --o





## Feedback

If you have any feedback, please reach out to us at info@ahatechnocrats.com


## Support

For support, email info@ahatechnocrats.com or join our facebook chanel https://www.facebook.com/aha.technocrats.

