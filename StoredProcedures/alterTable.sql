Alter table Users add IsAccepted bit;
Alter table Users add UpdatedAt Datetime;
Alter table Users add CreatedAt Datetime;

Alter table Roles add UpdatedAt Datetime;
Alter table Roles add CreatedAt Datetime;

Alter table Users
ADD CONSTRAINT Accept
DEFAULT '0' FOR IsAccepted

select * from Users
ALTER TABLE Customers
ADD Email varchar(255);



