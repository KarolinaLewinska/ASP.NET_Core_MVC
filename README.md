# ASP.NET Core MVC
The other co-authors: [Justyna Gapys](https://github.com/justynagapys), [Aleksandra Okrój](https://github.com/aleksandraokroj)<br />
System for managing students’ fictional personal data.<br />
In order to create some functionalities in this project was used [Microsoft Tutorials](https://docs.microsoft.com/pl-pl/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application).<br />

## Database first project <br />
![DB](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/Db.PNG)<br />
- Usage of Scaffolding in order to generate basic CRUD operations, <br />
- Range validator class for a date of birth entity (**rangeValidator.cs**),<br />
- Generating authentication DB via Package Console.<br />

## Validation results<br />
- Register and my account views,<br />
![registerMyAccount](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/authViews.PNG)<br />

- Login view,<br />
![registerMyAccount](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/loginViews.PNG)<br />

## StudentsController<br />
- Sorting, filtering functionalities,<br />
![searchSort](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/searchView.PNG)<br /><br />

- Paging (**Paging.cs**) functionality,<br /><br />
![paging](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/pagingView.PNG)<br />
- Session variable which informs about previously added/edited/deleted student’s data,<br />
- Server-side validaton for uniqueness of data (email, phone numer, PESEL, student ID number),<br />
![serverValidation](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/serverValidation.PNG)<br />
- Information via TempData about successfully added student’s data,<br />
- Session variable informing about previously added student’s data,<br />
- Try-catch error handling with dedicated page for error 404,<br />
![errorsViews](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/errorView.PNG)<br />

- **Edit Action (POST):**<br />
- Server-side validaton for uniqueness of data (email, phone numer, PESEL, student ID number),<br />
- Information via TempData about successfully edited student’s data,<br />
- Session variable which informs about previously edited student’s data,<br />
- Try-catch error handling with dedicated page for error 404,<br /><br />


- **Delete Action (POST):**<br />
- Information via TempData about successfully deleted student’s data (visible on Index page),<br />
- Try-catch error handling with dedicated page for error 404,<br />

## Views<br />
### Index.cshml<br />
![IndexView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/IndexView.PNG)<br />

### Create.cshtml<br />
![CreateView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/CreateView.PNG)<br />

### Edit.cshtml<br />
![EditView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/EditView.PNG)<br />

### Details.cshtml
![DetailsView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/DetailsView.PNG)<br />

### Delete.cshtml**<br />
![DeleteView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/DeleteView.PNG)<br />

### Index.cshtml (HomeController) 
– showing after logout from system,<br />
![LogoutView](https://github.com/KarolinaLewinska/ASP.NET_MVC_Core_App/blob/master/ReadmeImages/logoutPage.PNG)<br />
