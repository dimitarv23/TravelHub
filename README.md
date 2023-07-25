# Recipes
## ℹ️ About
An ASP.NET Core 6 application for SoftUni's final project assignment.
A Travel Agency, in which the organisers can organise trips/holidays and users can enroll for a certain trip/holiday.
It has the following functionalities:

## 🔬 Functionalities
There are three roles in the application:
- Guest - People that haven't registered / logged in.
- User - People that have logged in. They cannot organize holidays, but can enroll in already organized ones.
- Organizer - People with this role can organize holidays.

### Guests can:
- See the welcome page
- Register
- Login

### Users can:
- See all travels (their home page)
- See details about each travel
- See all destinations
- See details about each destination
- See all hotels
- See details about each hotel
- Add a review to a hotel
- See only his bookings
- Create a booking
- Remove his own booking from a certain travel
- Logout

### Organizers can:
- See all travels (their home page)
- See details about each travel
- Organize travels
- Edit travels
- Delete travels
- See all destinations
- See details about each destination
- Add new destinations
- Delete destinations
- See all hotels
- See details about each hotel
- Add new hotels
- Edit hotels
- Delete hotels
- See all bookings made by users
- Delete a booking from a certain user
- Logout

## 🔧 Technologies Used
- ASP.NET 6
- Entity Framework Core
- SQL Server Database
- HTML & CSS
- Javascript
- NUnit
