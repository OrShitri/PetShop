<img align="center" alt="airport" style="padding-right:10px;" src="https://images.squarespace-cdn.com/content/v1/572e05c45559862dca6424ff/1463971934544-QF606UIFUBLI50DWF1YD/petshop-logo-4+2.png" />  

# Pet Shop
PetShop is an Asp.Net Core MVC application of an online catalog for a pet shop.
<br>
Customers can view the catalog and navigate the site by selecting a category, view the details of the animal and leave comments on the animals.
<br>
An admin can also edit, add and delete an animal, as well as edit and delete comments.
<br>
The application uses Microsoft's IdentityUser Class to authenticate users.
<br>
The application is divided into 4 separate projects (Client, Data, Models, Services), with relevant references.
<br>
So each project is responsible for a different part.
<br>

## Data Base
<br>
The application saves all the data of the animals, pictures, comments, categories, etc. in a database on SQL Server (MMSQL)
<br>
The application manages another database called authentication, on which all the information related to users is saved such as email, phone, username and password, etc. (only the hash of the password is saved in the database).
<br>

### Dependencies
* .Net Core
* ASP.Net Core MVC
* SQL Server
* Bootstrap
* Jquery (jquery-validation, jquery-validation-unobtrusive)

### Installing
* Pull from here
* Add a migration and update the local database (for the Authentication DB)
* In the client project in the Program.cs file add the following lines of code under the line of code,
  <br>
  "var app = builder.Build();" (line 38):
  <br>
  using (var scop = app.Services.CreateScope())
  <br>
  {
  <br>
      var ctx = scop.ServiceProvider.GetRequiredService<MyContext>();
  <br>
      ctx.Database.EnsureDeleted();
  <br>
      ctx.Database.EnsureCreated();
  <br>
  }
* Then when running the project, the local database (for the PetShop DB) will be created (code first), after the database is created, the above lines can be deleted

### Executing Program
* Compile
* Run the exe
