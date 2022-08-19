# Animal Shelter API

#### By _Filmer Tolentino_

#### _An API for keeping track of dogs and cats in an animal shelter._

## Technologies Used

* _C#/.NET_
* _SQL Workbench_
* _MVC_
* _Entity Framework_
* _Identity_
* _JwtBearer_
* _Swagger_

## Description

An API created for use by an animal shelter to keep track of the dogs and cats in their care.

## Setup/Installation Requirements
_Requires console application such as Git Bash, Terminal, or PowerShell_

1. Open Git Bash or PowerShell if on Windows and Terminal if on Mac
2. Run the command

    ``git clone https://github.com/ftolentino/AnimalShelterAPI.Solution.git``

3. Run the command

    ``cd AnimalShelterAPI.Solution``

* You should now have a folder `AnimalShelterAPI` with the following structure.
    <pre>AnimalShelterAPI.Solution
    ├── .gitignore 
    ├── ... 
    └── AnimalShelter
        ├── Controllers
        ├── Models
        ├── ...
        ├── README.md
        └── Startup.cs</pre>

4. Add a file named appsettings.json in the following location, inside AnimalShelter folder 

    <pre>AnimalShelterAPI.Solution
    ├── .gitignore 
    ├── ... 
    └── AnimalShelter
        ├── Controllers
        ├── Models
        ├── ...
        ├── Startup.cs
        └── <strong>appsettings.json</strong></pre>
      
5. Copy and paste below JSON text in appsettings.json.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  },
  "JwtConfig": {
    "Secret" : "[YOUR-SECRET-HERE]"
  }
}

```

7. Replace [YOUR-PASSWORD-HERE] with your MySQL password.

8. Replace [YOUR-SECRET-HERE] with your random length 32 string.

9. Run the command

    ```dotnet ef database update```


<strong>To Run</strong>

Navigate to the following directory in the console
    <pre>AnimalShelterAPI.Solution
    └── <strong>AnimalShelter</strong></pre>

Run the following command in the console

  ``dotnet build``

Then run the following command in the console

  ``dotnet run``

This program was built using _`Microsoft .NET SDK 5.0.401`_, and may not be compatible with other versions. Cross-version performance is neither implied nor guaranteed, your actual mileage may vary.

## API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using the JSON Web Token
In order to be authorized to use the POST, PUT, DELETE functionality of the API, please authenticate yourself through Postman.
* Open Postman and create a POST request using the URL: `http://localhost:5000/api/users/authmanagement/register`
* Add the following query to the request as raw data in the Body tab:
```
{
    "name": "Test User",
    "email": "Test@Test.com",
    "password": "epicodus"
}
```
* The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab after selecting "Bearer Token" from the dropdown menu.

###  Swagger Documentation 
To view the Swagger documentation for the AnimalShelter API, launch the project using `dotnet run` using Terminal or Powershell, then input the following URL into your browser: `http://localhost:5000/swagger`

###  Swagger Authorization 
In order to utilize Swagger and interact with the API, you will first need to authenticate yourself through Postman. 
* Once you have completed authorization and have obtained your Bearer Token, navigate back to `http://localhost:5000/swagger` then click on the `authorize` button in the top right corner.
* From there, you must type in `Bearer` followed by your `Token`.
* After you have inputted the necessary `Bearer Token`, click Authorize.
* Once successfully authorized, you will be able to utilize the Swagger docs to interact with the API.

### Animals
Access information on animals currently in the shelter.

#### HTTP Request Structure
```
GET /api/Animals
POST /api/Animals
GET /api/Animals/{id}
PUT /api/Animals/{id}
DELETE /api/Animals/{id}
```
* To utilize the POST request and create a new instance of an animal, the following information is required.
```
{
  "animalId": 0,
  "name": "string",
  "species": "string",
  "breed": "string",
  "postDate": "string"
}
```

#### Example Query
```
https://localhost:5000/api/Animals/1
```
#### Sample JSON Response
```
{
  "animalId": 1,
  "name": "Dara",
  "species": "dog!!",
  "breed": "German Shepherd",
  "postDate": "16 August 2022"
}
```

## Known Bugs

* _No known issues_

## License

[MIT](/LICENSE)

Copyright (c) 2022 Filmer Tolentino