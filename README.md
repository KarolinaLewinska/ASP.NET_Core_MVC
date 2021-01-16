# ASP.NET_MVC_Core_App
System for managing students’ fictional personal data.<br />
**Project created by:** [Karolina Lewińska](https://github.com/KarolinaLewinska), [Justyna Gapys](https://github.com/justynagapys), [Aleksandra Okrój](https://https://github.com/aleksandraokroj)<br />
In order to create some functionalities in this project we used Microsoft Tutorial: [click here](https://docs.microsoft.com/pl-pl/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application)<br />
**Architecture:** MVC<br />
**Framwork:** .NET Core<br />
**Language:** C#<br />
**Database first project (Microsoft SQL Server Management Studio)** <br />
![DB](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/Db.PNG)<br />
- Usage of **Scaffolding** in order to generate basic CRUD operations.<br />
- **Client side validation of model (Models/Student.cs):**<br />
![validation](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModel.PNG)<br />
![validation2](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModel2.PNG)<br />
![validation3](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModel3.PNG)<br />
![validation4](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModel4.PNG)<br />
**- Results:**<br />
![validationResult](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModelResult.PNG)<br />
![validationResult2](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/validationModelResult2.PNG)<br />
- Adjusted **range validator class** for a date of Birth entity in the model (**rangeValidator.cs**):<br />
![rangeValidator](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/rangeValidator.PNG)<br />
- Generating authentication DB via Package Console:<br />
![authCommand](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/authCommand.PNG)<br />
- Adding Identity Configurations in **Sartup.cs**:<br />
![AuthConfig](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/authConfig.PNG)<br />
- **Results (with validation):**<br />
**- register and my account views:**<br />
![registerMyAccount](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/authViews.PNG)<br />
**- login view:**<br />
![registerMyAccount](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/loginViews.PNG)<br />
- **StudentsController:**<br />
**- Authorize attribute** to unable access without authentication,<br />

- **Index Action (GET):**<br />
- sorting, filtering functionalities:<br />
![searchSort](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/searchView.PNG)<br />
- paging (**Paging.cs**) functionality:<br />
![paging](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/pagingView.PNG)<br />
- session variable informing about previously added/edited/deleted student’s data (depending on previous CRUD operation).<br />

- **Create Action (POST):**<br />
- server-side validaton for uniqueness of data (email, phone numer, PESEL, student ID number),<br />
![serverValidation](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/serverValidation.PNG)<br />
- information via TempData about successfully added student’s data,<br />
- session variable informing about previously added student’s data,<br />
- try-catch error handling with dedicated pages for error 404.<br />
![errorsViews](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/errorView.PNG)<br />

- **Edit Action (POST):**<br />
- server-side validaton for uniqueness of data (email, phone numer, PESEL, student ID number),<br />
- information via TempData about successfully edited student’s data,<br />
- session variable informing about previously edited student’s data,<br />
- try-catch error handling with dedicated pages for error 404.<br />

- **Delete Action (POST):**<br />
- information via TempData about successfully deleted student’s data (visible on Index page),<br />
- try-catch error handling with dedicated pages for error 404.<br />

- **HTTP statuses and session configuration in Startup.cs:**<br />
![httpSessionConfig](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/httpSessConfig.PNG)<br />
![httpSessionConfig2](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/httpSessConfig2.PNG)<br />
- **Created own CSS style (master.css)**<br />

- **Cross-Site Request Forgery security (AntiForgeryToken attribute)**<br />

- **Views results:**<br />
**- Index.cshml**<br />
![IndexView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/IndexView.PNG)<br />

**- Create.cshtml**<br />
![CreateView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/CreateView.PNG)<br />

**- Edit.cshtml**<br />
![EditView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/EditView.PNG)<br />

**- Details.cshtml**
![DetailsView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/DetailsView.PNG)<br />

**- Delete.cshtml**<br />
![DeleteView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/DeleteView.PNG)<br />

**- Index.cshtml (HomeController) – showing after logout from system**<br />
![LogoutView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/logoutPage.PNG)<br />




