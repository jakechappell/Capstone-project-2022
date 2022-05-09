# Deployment 

## Server
- The project uses localhost as its server while running. The project uses two ports for localhost:
  #### Back-end
  - http://localhost:5000
  #### Front-end
  - http://localhost:8080

## Installation and Setup
#### Prerequisites
  - Ensure the following are installed before cloning the repository: <br>
<img src=https://img.shields.io/badge/.NET%205-v5.0.402-blue>
<img src=https://img.shields.io/badge/npm-v6.14.15-red>
<img src=https://img.shields.io/badge/Vue%20CLI-v4.5.13-brightgreen>
<img src=https://img.shields.io/badge/Microsoft%20SQL%20Server%202019-v15.0.2000.5-blueviolet>
<img src=https://img.shields.io/badge/Microsoft%20SQL%20Server%20Management%20Studio%2018-v18.9.2-purple>
<img src=https://img.shields.io/badge/Docker%20Desktop-v4.4.4-9cf>
<br>

- `.NET 5 SDK v5.0.402`
- `NodeJS v14.18.0` for `npm` usage
- `Vue CLI v4.5.13`
- `Microsoft SQL Server 2019 v15.0.2000.5 for database support`
- `Microsoft SQL Server Management Studio 18 v18.9.2 for database management`
- `Cypress v9.5.4` (installed on npm install)
  - Once installed, clone the Bitbucket project repository (https://bitbucket.org/accutechdev/bsu.developer-portal/src/master/) into a folder of your choosing.

## Starting/Stopping System Operations
### To start system operations...
#### &emsp;Database:
- Open SQL Server Management Studio and connect to your Desktop server
- Right click on `Databases` and select `Restore Database`
- Select the radio button labeled `Device` and click the `Browse (...)` button next to the input box
- In the window that comes up, select `File` from the dropdown menu
- Select any existing paths in the `Browse Media` box and click `Remove`
- Select `Add`
- Find the project repository in the file structure that comes up, select the 'CheetahDB.bak' database backup file, and select `Ok`
- Select the 'CheetahDB.bak' file path in the `Browse Media` box and click `Ok`
- In the restore database window, write 'CheetahDB' in the database input box if it's not already inputed
- Click `Ok` to restore the CheetahDB database from the backup file
- If there are any issues, check to make sure the proper connection string is used in the back-end file "Startup.cs"
    - "CheetahDbLocal" for local machine database and "CheetahDbDocker" for a database in a Docker container.

#### &emsp;Back-end:
- In a CLI, move into the *\dotnet\Portal\Portal* folder and first build the project .dll
    - `dotnet build "Portal.csproj"`
- Then, move into the *\bin\Debug\net5.0* folder to run the .dll
    - `dotnet run Portal.dll`
- The back-end should spin up, and in a browser you can go to http://localhost:5000 and should see the back-end swagger page
**OR**
- Open the project solution in Visual studio 2019
    - Select 'Portal' from the run dropdown menu and click the run button
    - http://localhost:5000 will open in your default browser

#### &emsp;Front-end:
- In a CLI, move into the *\vue* folder and first install the dependencies
    - `npm install`
- Then, in the same folder, start the front-end with npm
    - `npm run serve`
- The front-end should spin up, and in a browser you can go to http://localhost:8080 and see the front-end web application pages
**OR**
- Open the 'vue' folder in Visual Studio Code
    - Hit 'Ctrl + ~' to open a shell in the vue folder
    - Run the command `npm run serve`
    - Navigate to http://localhost:8080

### To stop system operations...
#### &emsp;Back-end:
- From the CLI running the back-end, input the command 'CTRL+C' to halt the operation.

#### &emsp;Front-end:
- From the CLI running the front-end, input the command 'CTRL+C'. The CLI will ask the user if they want to terminate the batch job. Input the command 'Y' to halt the operation.

## Starting/Stopping System Operations with Docker
### To start system operations...
- Run the following docker-compose command in the root folder of the repository (where docker-compose.yml is):
    - `docker-compose up --build`
    - This might take some time for the initial build.
    - If Docker prompts to share folder(s), confirm them.
- If you want to rebuild from scratch, try using --nocache option.
    - `docker-compose build --no-cache`
    - Then running `docker-compose up`

### To stop system operations...
- Change directory to the root folder of the repository (where docker-compose.yml is):
    - `docker stop bsudeveloper-portal` to stop the containers
    **OR**
    - Open Docker Desktop and click the stop button on each container individually or the root container

## Troubleshooting
- In case of an issue, consult the following steps to properly troubleshoot the issue:
    - Ensure the back-end and front-end are both running properly (see the Starting/Stopping System Operations section for more detail).
    - Ensure that the database has been restored correctly (see the Starting/Stopping System Operations section under the "Database" tab for more detail)
    - In case of an issue with the Request Access form:
        - Ensure the entire form is filled out properly before submission.
        - Check the appsettings.json file (dotnet/Portal/Portal/appsettings.json) to ensure 'Enabled' is set to 'true'.

## Error Logging
- Errors can be found logged in the CLI used to run the project.

## Critical Sections
- The critical sections that are mostly likely to fail are in the Request Access section of the Login page and the loading of data stored in the Database.
    - When filling out the Request Access form, ensure that each field in the form is filled out. If any field is left blank, the access request may not properly send and the user may receive an error.
    - The email sent after submitting the Request Access form may fail to send. Ensure that '"Enabled": true' is set in 'dotnet/Portal/Portal/appsettings.json'--if 'Enabled' is set to 'false', the email may fail to send.
    - If the References page displays a spinner and does not load information in a reasonable amount of time, more than likely the database backup file was not restored correctly. Ensure that the database can be seen in SQL Server Management Studio and that queries can be run on it. Alternatively if you are running from Docker, assure that the steps in the above section "Starting/Stopping System Operations with Docker" were done correctly.
- The sandbox test console on the reference page can give several different messages relating to problems that arose when testing an endpoint. The messages are as follows:
    - "Unauthorized. Check your Cheetah API access": The user no longer has a valid JWT token and should check that they still have access to the API
    - "Unable to communicate with Accutech. Please try again later": A connection to Accutech servers for testing purposes was not able to be made
    - "Bad request. Please try again with different values": The parameters the user inputed do not exist in context to Accutech or their clients
    - "Response too large. Try adding a parameter": The response the call has given is too large for the app to handle. The user should should try inputing a parameter for a more concise response.