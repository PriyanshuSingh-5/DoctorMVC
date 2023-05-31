Create Database DoctorListMVCDB

Create Table Roles (
RoleId int IDENTITY (1,1) PRIMARY KEY NOT NULL,
Role varchar(20) NOT NULL)

CREATE TABLE Users (
     UserID Bigint PRIMARY KEY IDENTITY(1,1),
	 Fullname Varchar(100) Not null,
     EmailID  Varchar(100) NOT NULL,
	Password Varchar(25) not null,
	ContactNo bigint,
    RoleID int FOREIGN KEY REFERENCES Roles(RoleId),
	Unique (EmailID)
);

drop table Users
insert into Users(UserName,)

ALTER TABLE Users
ADD UNIQUE (UserName);

insert into Users(Fullname,EmailID,Password,ContactNo,RoleID)Values('Administration','admin@gmail.com','Admin@123',7689045673,1)
select * from Users
select * from Roles
insert into Roles(Role)values('Doctor')