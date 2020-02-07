# External Interface Requirements

This section provides a detailed description of all inputs into and outputs from the system. It also gives a description of the hardware, software and communication interfaces and provides basic prototypes of the user interface. 

## User interfaces

### Login

Interface which allow to connect to the user’s profile interface.

![Login](https://i.imgur.com/h7eoHF4.png?1)

### Register

Interface which allows the user to create a profile which he can use every time he logs in again.

![Register](https://i.imgur.com/Ceoq3x6.png?1)

### Admin task

Interface which allow the admin user to manage the user’s profiles. 

![Admin tasks](https://i.imgur.com/IAdVkNU.png?1)

### User right management

Interface which manage the rights between the admin users and the normal users.

![User right management](https://i.imgur.com/nEHc5v8.png?1)

### User interface

Interface for the user which displays all the information related to the user.

![User interface](https://i.imgur.com/vwDBtUm.png?1)

### Medics proposition interface

An interface that displays the functionality which propose to the user the best option of medication according to his needs.

![Medic prop](https://i.imgur.com/DMr5MlB.png?1)

## Hardware interfaces

The windows application doesn’t have any designated hardware, it does not have any direct hardware interface.

## Software interfaces

Our solution is functioning on Windows 7 or Windows 10.  

The solution is coded in C#, by using Visual Studio, and windows form. 

Our web application communicates with the database in which is contained all the information, user profiles, medics.
For this feature, we will use MS SQL database. 

## Communications interfaces

Since we have only a web application, the communication is handled by the underlying operating systems for the web portal.

![Communication Diagram](https://i.imgur.com/Mj5see2.png)

For our software, we have 3 types of users.

- Not registred user can only access to Index, Registration and Login.

- Registred user can access to their User interface where they can find their User profile and their Medication proposition. 

- Administators user can access to everything. Admin can access more precisely to Task Administration, Users Rights Managements and Database Management.

## Data Flow Diagram

![https://i.imgur.com/w4IIaJ3.png](https://i.imgur.com/w4IIaJ3.png)
