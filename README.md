# GymApp - ASP.NET MVC 

## About Project
I created an web application which allows users to manage their workouts and memberships.
Users can login and register, there are also role based authorization. Application is responsive. 

### User Functions:
- Login and register
- Change password
- Choose membership
- Display trainers and their trainings
- Sign up for training
- Users can see their training reservations

### Admin Functions
- Login and register
- Change password
- Assign roles to users
- Add new trainings
- Add new memberships 
- See every user training reservations
- Edit trainings 
- Delete trainings


## Technology
- **ASP.NET MVC (8.0)**
- **Entity Framework**
- **MySQL Server**
- **HTML**
- **CSS**
- **AutoMapper**
- **ASP.NET.Core Identity**
- **MediatR with CQRS**
- **Repository Pattern**
- **XUnit**
- **Moq for Unit Tests**
- **FluentValidation**


## Database diagram
![diagram sql gymapp](https://github.com/user-attachments/assets/d7aad9c3-a532-43fa-8123-25027602471a)

## Some screenshots from application
![screen1](https://github.com/user-attachments/assets/98fe27b1-b545-4820-ab6c-2e5f9f6359fd)
![screen2](https://github.com/user-attachments/assets/a6059ec2-5af5-437e-a885-bc1f98421e9e)
![screen3](https://github.com/user-attachments/assets/15906cd7-cf64-4f6a-be73-0bee9fac7cab)
![screen4](https://github.com/user-attachments/assets/9932ed03-b034-44b3-bcff-775aed6b6fae)
![screen5](https://github.com/user-attachments/assets/5b46d5ca-a45b-4920-b42c-17fe727cca4a)







## How to run an app
1. Clone repository:
   ```bash
   git clone https://github.com/GymApp.git
2. Open the project in Microsoft Visual Studio  

3. Configure the database connection in the appsettings.json file.

4. Apply migrations to database
   ```bash
   dotnet ef database update

5. Run the application
   ```bash
   dotnet run

