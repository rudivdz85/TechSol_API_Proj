Notes:

- I put the allowed hosts for the CORS policy to All/* for this project for ease of use, in a production application this would not be the case and it would be set to allow only neccesary IPs
- I created a few tables to simulate a more realistic full spectrum application, but only based the functionality of the app on the customers table.
- On a production application I would advise the use of Stored Procedures, I used raw SQL queries in my DB Class in this app for speed and ease of coding.
- I have manually coded all the ports to run on normal http localhost:5241 for ease of use, this would be made much more secure and robust on a production application



Instructions:

How to run .NET Web API:
Navigate to the Project Folder in your command line and enter this command: dotnet run

To Serve Angular App:
Navigate to the Client App Folder in your command line and enter this command: ng serve --open

Please click on the Customers tab on the Nav menu to interact with the Customers Data. 
(The DB is set up to connect to localhost on Windows Authentication with a DB called TechSolutionsDB, either create a DB with the same name on your localhost SQL server or replace the name in the appsettings.json)