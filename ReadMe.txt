Notes:

- I put the allowed hosts for the CORS policy to All/* for this project for ease of use, in a production application this would not be the case and it would be set to allow only neccesary IPs
- I created a few tables to simulate a more realistic full spectrum application, but only based the functionality of the app on the customers table.
- On a production application I would advise the use of Stored Procedures, I used raw SQL queries in my DB Class in this app for speed and ease of coding.
- I have manually coded all the ports to run on normal http localhost:5241 for ease of use, this would be made much more secure and robust on a production application



Instructions to run:

How to run .NET Web API: (Make sure to have .NET SDK Installed first)
Navigate to the Project Folder in your command line and enter this command: dotnet ru
---------------------------------------------------------
To Serve the Angular App:

Running an Angular application via the command line is straightforward. First, ensure that you have Node.js and the Angular CLI installed. If you haven't installed Angular CLI yet, you can install it globally using npm:

npm install -g @angular/cli
Once Angular CLI is installed, you can use it to serve your Angular application.

Steps to Run Angular Application:
Open Command Line:
Open your command line tool (Command Prompt, PowerShell, Terminal, etc.).

Navigate to Your Project Directory:
Use the cd command to navigate to your Angular project's directory. Replace path-to-your-project with the actual path to your Angular project.

cd path-to-your-project
Install Dependencies:
If it's the first time you are running the project or if there are new dependencies added, run:


npm install
This command installs all the dependencies defined in your project's package.json file.

Serve the Application:
Start the development server using Angular CLI:


ng serve
By default, this will launch the server on http://localhost:4200. You can open this URL in your web browser to view your application.

Optional: Specify a Different Port:
If you want to serve your application on a different port, use the --port flag:

ng serve --port 4300
Replace 4300 with your preferred port number. Then, access your app at http://localhost:4300.
------------------------------------------------------

Instructions to use:

Please click on the Customers tab on the Nav menu to interact with the Customers Data. 
(The DB is set up to connect to localhost on Windows Authentication with a DB called TechSolutionsDB, either create a DB with the same name on your localhost SQL server or replace the name in the appsettings.json)