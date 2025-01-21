# GymApp - ASP.NET MVC 

## About Project
I created an web application which allows users to manage their workouts and memberships.
Users can login and register, there is also role based authorization. Every user will receive an email after registering to the app.
Currently, email sending  works only on Gmail accounts.
Application is responsive.

## Status
I'm currently working on 2 factor authentication. When user wants to login, he will receive an email with a code which he has to write in a special place to confirm his identity

### User Functions:
- Login and register
- Change password
- Choose membership
- Display trainers and their trainings
- Sign up for training
- Users can see their training reservations
- Users can download pdf file with their training reservation confirmation

### Admin Functions
- Login and register
- Change password
- Assign roles to users
- Add new trainings
- Add new memberships 
- See every user training reservations
- Edit trainings 
- Delete trainings


## Built With
- **ASP.NET MVC (8.0)**
- **Entity Framework**
- **MySQL Server**
- **HTML**
- **CSS**
- **AutoMapper**
- **ASP.NET.Core Identity**
- **MediatR with CQRS**
- **Domain Driven Design**
- **Repository Pattern**
- **XUnit**
- **Moq for Unit Tests**
- **FluentValidation**


## Database diagram
![diagram sql gymapp](https://github.com/user-attachments/assets/d7aad9c3-a532-43fa-8123-25027602471a)

## Some screenshots from application
![screen1](https://github.com/user-attachments/assets/98fe27b1-b545-4820-ab6c-2e5f9f6359fd)
![login](https://github.com/user-attachments/assets/5602fdab-5681-48d3-8157-654f6accbfaf)
![screen3](https://github.com/user-attachments/assets/75ce60ad-c014-45e6-aca7-fdf90b80c578)
![screen4](https://github.com/user-attachments/assets/9932ed03-b034-44b3-bcff-775aed6b6fae)
![screen5](https://github.com/user-attachments/assets/5b46d5ca-a45b-4920-b42c-17fe727cca4a)







## How to run an app
1. Clone repository:
  ```cmd
   git clone https://github.com/GymApp.git
  ```
2. Open the project in Microsoft Visual Studio  

3. Configure the database connection in the appsettings.json file.

4. Apply migrations to database
  ```cmd
   dotnet ef database update
  ```

5. Run the application
  ```cmd
   dotnet run
  ```
## Author
Patryk Rekiel

