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

create table PatientProfile(
PatientID int Primary key identity(1,1),
DOB date,
Gender varchar(25),
BloodGroup char(3),
PatientImage varchar(255),
HealthConcern varchar(50),
MedicalHistory varchar(255),
InsuranceProvider varchar(50),
UserID int FOREIGN KEY REFERENCES Users(UserID),
Istrash bit,
CreatedAt datetime,
UpdatedAt datetime
)

Alter table PatientProfile
ADD CONSTRAINT trash
DEFAULT '0' FOR Istrash


Create table Category(
CategoryID int Primary key Identity(1,1),
Specialization varchar(50)
)
insert into Category(Specialization) Values('Surgeon')
select * from Category
create table Services(
ServiceId int Primary key Identity(1,1),
Service varchar(250),
ServiceFee float
)

insert into Services(Service,ServiceFee)values('Consultation',750)
insert into Services(Service,ServiceFee)values('RoutineCheckup',1500)
insert into Services(Service,ServiceFee)values('Prescription',550)
insert into Services(Service,ServiceFee)values('PathologyTest',250)
insert into Services(Service,ServiceFee)values('Surgery',37750)
insert into Services(Service,ServiceFee)values('Physical examination',750)


Create table ScheduleLocation(
ScheduleId int primary key Identity(1,1),
ScheduleTime time,
Location varchar(250),
DoctorID int FOREIGN KEY REFERENCES DoctorProfile(DoctorID),
)
drop table ScheduleLocation

insert into ScheduleLocation(ScheduleTime,Location,UserID,RoleID) values('12:45:30','Bangalore,HSR', 2,3)
insert into ScheduleLocation(ScheduleTime,Location,UserID,RoleID) values('17:45:30','Electroniccity,BLR', 2,3)



Create table DoctorProfile(
DoctorID int Primary key Identity(1,1),
DoctorImage varchar(255),
Age int,
Gender varchar(25),
Qualification varchar(150),
Experience float,
UserID int FOREIGN KEY REFERENCES Users(UserID),
RoleID int FOREIGN KEY REFERENCES Roles(RoleID),
ServiceId int FOREIGN KEY REFERENCES Services(ServiceId),
IsTrash bit,
CreatedAt datetime,
UpdatedAt datetime
)
drop table DoctorProfile
Alter table DoctorProfile
ADD CONSTRAINT istrash
DEFAULT '0' FOR IsTrash

ALTER TABLE DoctorProfile
ADD CategoryID int FOREIGN KEY REFERENCES Category(CategoryID);

ALTER TABLE DoctorProfile
DROP COLUMN ServiceId;

alter table DoctorProfile drop constraint FK__DoctorPro__Servi__57DD0BE4;



create table Appointment(
AppointmentID int Primary key identity(1,1),
Concerns varchar(255),
Appointmentdate Date,
StartTime time,
EndTime time,
IsActive bit default '0',
IsTrash bit default '0',
DoctorID int FOREIGN KEY REFERENCES DoctorProfile(DoctorID),
PatientID int FOREIGN KEY REFERENCES PatientProfile(PatientID),
ScheduleID int FOREIGN KEY REFERENCES ScheduleLocation(ScheduleID),
CreatedAt datetime,
UpdatedAt datetime
)

drop table Appointment