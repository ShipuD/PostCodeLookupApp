# PostCodeLookupApp
The Project has 2 parts:
PostCodeLookupAPI:Restfu api with full back end and Database conenctivity and data layer
PostCodeUIClient:  This contains angular based UI as client and uses Typescript.
DB is SQL server. COde used enity framework code first

1) It has 2 table one with seeded data for postcode
2) It has userData which is used to capture the use entered data.

Set up Code first migration:

1) The data store used is SQL DB-> Change the connectionstring in appconfiguration to your Db instance name 
2) Add migration using powershell(Package manager command) commands

       a) Add-Migration InitialCreate
       b)  Update-Database
       c)  remove-migration
	   
3)The above migration is created for PostcodeDB with Schema using entity framework code first
4) The Database will be seeded with given deleivery options first time

Running Application:

1) Run API in Visual studio(Debugg mode) using IIs express
   start API https://localhost:44376/weatherforecast
   Ignore weatherforecast which is default API
   PostCodeLookUp is one having implementaion
   
2) Angular using Visual studio code 
open terminal and type
    npm install
	ng serve
	start client in https://localhost:4200

3) test the UI by giving postcode and check Database table UserData that captures users postcodes.
		
