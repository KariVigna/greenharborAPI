# _Green Harbor API_

#### By _Jessica Hattig, Kari Vigna, Greg Stillwell, Mac Granger, and Will Jolley_

#### _An API of Communal Compost Piles for the Green Harbor App_

## Technologies Used

* C#
* Razor HTML
* CSS
* .NET 6.0
* Entity Framework Core
* JSON
* MySQL
* Visual Studio Code
* Github
* Git
* Swagger

## Description

GreenHarborApi is an ASP.NET Core web API that allows users to populate a database with communal compost piles and information about their location, contact info, and what kinds of debris they accept. Users can edit and delete their entries, and they are able to view all the compost piles in the database and filter their results by zip code or city.     

## Setup Instructions

- Note: An installation of the .NET SDK is required in order to run this application locally. [See Here](https://dotnet.microsoft.com/en-us/) for installation.

- Optionally, download and install Postman [here](https://www.postman.com/downloads/).

1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's directory called "GreenHarborApi/". 
3. Create a file named `appsettings.json`: `$ touch appsettings.json`
4. Within `appsettings.json` add the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=green_harbor_api;uid=[Your UserID];pwd=[Your Password];"
      }
    }
    ```
5. Set up the database: `$ dotnet ef database update`
6. Navigate to the project directory: `$ cd GreenHarborApi`
7. Run `$ dotnet watch run` in the command line to start the project in development mode with a watcher.
8. Open the browser at: _https://localhost:7000/swagger/index.html_. If you cannot access localhost:7000 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Endpoints

Base URL: 
  ```
  https://localhost:7000
  ```

HTTP Request Structure
  ```
  GET /api/Composts
  GET(by id) /api/Composts/{id}
  GET(by city) /api/Composts?city=[name of city]
  GET(by zip code) /api/Composts?zip=[zip code]
  POST /api/Composts/{id}
  PUT /api/Composts/{id}
  DELETE /api/Composts/{id}
  ```

Example GET Request
  ```
  https://localhost:7000/api/Composts/8
  ```

Sample Response Body
  ```
  {
    "compostId": 8,
    "zip": "97702",
    "city": "Bend",
    "location": "Oregon",
    "contactName": "Bart",
    "contactPhone": "5418889999",
    "contactEmail": "Barrrrrt@gmail.com",
    "contents": "mixed, animal and food"
  },
  ```

Search By City Example Request
  ```
  https://localhost:7000/api/Composts?city=Portland
  ```

Sample Response Body
  ```
   {
    "compostId": 5,
    "zip": "97215",
    "city": "Portland",
    "location": "Zorbie",
    "contactName": "Will Jolley",
    "contactPhone": "XXXXXXXXX",
    "contactEmail": "word@thing.gov",
    "contents": "what"
  },
  {
    "compostId": 9,
    "zip": "97214",
    "city": "Portland",
    "location": "Oregon",
    "contactName": "Schlep",
    "contactPhone": "5418889999",
    "contactEmail": "Schlep@yahoo.com",
    "contents": "Plant waste"
  },
  {
    "compostId": 10,
    "zip": "97215",
    "city": "Portland",
    "location": "Oregon",
    "contactName": "Mac",
    "contactPhone": "5031231234",
    "contactEmail": "Mac@gmail.com",
    "contents": "Yard debris"
  }
  ```

  Example POST Request
  ```
  https://localhost:7000/api/Composts

  {
    "zip": "97031",
    "city": "Hood River",
    "location": "Hood River",
    "contactName": "Jennifer",
    "contactPhone": "5035032256",
    "contactEmail": "blah@blah.com",
    "contents": "leaves"
  }
  ```
  * Requests must be made in JSON 
  * compostId is auto-implemented

  Example PUT Request
  ```
  https://localhost:7000/api/Composts/{id}

  {
    "compostId": 7,
    "zip": "97031",
    "city": "Hood River",
    "location": "Hood River",
    "contactName": "Jennifer",
    "contactPhone": "5035032256",
    "contactEmail": "blah@blah.com",
    "contents": "leaves, yard debris"
  }
  ```
  * compostId must be declared in the request body for PUT requests

  Example DELETE Request
  ```
  https://localhost:7000/api/Composts/{id}

  {
    "compostId": 7,
    "zip": "97031",
    "city": "Hood River",
    "location": "Hood River",
    "contactName": "Jennifer",
    "contactPhone": "5035032256",
    "contactEmail": "blah@blah.com",
    "contents": "leaves, yard debris"
  }
  ```
  * compostId must be declared in the request body for DELETE requests too

## Known Bugs
* _Please visit this projects [GitHub repository]() to submit Issues and Pull Requests._

## License

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) Kari Vigna, Jessica Hattig, Will Jolley, Greg Stillwell, Mac Granger 2023 