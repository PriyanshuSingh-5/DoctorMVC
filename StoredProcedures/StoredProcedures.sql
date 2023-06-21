create or alter procedure uspUserLogin 
(  
@EmailID varchar(100),  
@Password varchar(25)
)
as  
SET XACT_ABORT on;
begin 
BEGIN TRY
BEGIN TRANSACTION;
DECLARE @result int = 0;
if((select count(EmailID) from Users where EmailID = @EmailID) = 0)
  begin;
		set @result = 2;
		THROW 52000, 'AdminID is invalid', -1;
		end  
else
	
Begin
SELECT * from Users where EmailID=@EmailID and Password=@Password
end

COMMIT TRANSACTION
return @result;
END TRY
BEGIN CATCH

IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END

exec uspUserLogin 'admi@gmail.com','admin@123'




---------getallDoctors and patients---




CREATE   PROCEDURE uspGetAllDoctors
	-- Add the parameters for the stored procedure here
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;

	select * from Users where RoleID = 3; 
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO




--------GetDocById----




Alter   PROCEDURE uspGetAllDocById
	-- Add the parameters for the stored procedure here
	@EmailID VARCHAR(100)
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from Users where EmailID = @EmailID) = 0)
	begin
		set @result = 2; 
		throw 5000,'User dont exist',-1;
	end
	select * from Users where EmailID=@EmailID;
	update Users set IsAccepted=1 where EmailID=@EmailID
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO







exec uspGetAllDocById 'adimft@gmail.com'


-----Register---
ALTER   PROCEDURE [dbo].[uspRegisterUser]
	-- Add the parameters for the stored procedure here
	@FullName varchar(50),
	@EmailID varchar(100),
	@Password varchar(25),
	@ContactNo bigint,
	@RoleID int,
	@UpdatedAt datetime,
	@createdAt datetime
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @UserID varchar;

	if((select count(EmailID) from Users where EmailID = @EmailID) = 1)
		begin;
		set @result = 2;
		THROW 52000, 'Email already exist', -1;
		end

	insert into Users(FullName,
	EmailID,
	Password,
	ContactNo,RoleID,UpdatedAt,CreatedAt) output Inserted.UserID into @Identity
	values(@FullName,
	@EmailID,
	@Password,
	@ContactNo,
	@RoleID,
	@UpdatedAt,
	@CreatedAt);

--	SELECT @new_identity = (select ID from @Identity);

	select UserID,
	FullName,
	EmailID,
	ContactNo
	from Users where UserID = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END



-----Adding patient profiles---
Alter  PROCEDURE uspAddPatientProfile
	-- Add the parameters for the stored procedure here
	@DOB date,
@Gender varchar(25),
@BloodGroup char(3),
@PatientImage varchar(255),
@HealthConcern varchar(50),
@MedicalHistory varchar(255),
@InsuranceProvider varchar(50),
@UserID int ,
@CreatedAt datetime,
@UpdatedAt datetime
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @PatientID varchar;

	

	insert into PatientProfile(DOB,
	Gender,
	BloodGroup,
	PatientImage,HealthConcern,MedicalHistory,InsuranceProvider,UserID,CreatedAt,UpdatedAt) output Inserted.PatientID into @Identity
	values(@DOB,
	@Gender,
	@BloodGroup,
	@PatientImage,@HealthConcern,@MedicalHistory,@InsuranceProvider,@UserID,@CreatedAt,@UpdatedAt);

--	SELECT @new_identity = (select ID from @Identity);

	select PatientID,
	DOB,
	Gender,
	BloodGroup,
	PatientImage,HealthConcern,MedicalHistory,InsuranceProvider,UserID,Istrash,CreatedAt,UpdatedAt
	from PatientProfile where PatientID = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END

-----Get Patient By Id--
Alter   PROCEDURE uspGetPatientById
	-- Add the parameters for the stored procedure here
	@UserID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from PatientProfile where UserID = @UserID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Patient dont exist',-1;
	end
	select * from PatientProfile where UserID = @UserID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO



----Adding patient Details---
Alter  PROCEDURE uspAddPatientProfile
	-- Add the parameters for the stored procedure here
	@DOB date,
@Gender varchar(25),
@BloodGroup char(3),
@PatientImage varchar(255),
@HealthConcern varchar(50),
@MedicalHistory varchar(255),
@InsuranceProvider varchar(50),
@UserID int ,
@CreatedAt datetime,
@UpdatedAt datetime
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @PatientID varchar;

	

	insert into PatientProfile(DOB,
	Gender,
	BloodGroup,
	PatientImage,HealthConcern,MedicalHistory,InsuranceProvider,UserID,CreatedAt,UpdatedAt) output Inserted.PatientID into @Identity
	values(@DOB,
	@Gender,
	@BloodGroup,
	@PatientImage,@HealthConcern,@MedicalHistory,@InsuranceProvider,@UserID,@CreatedAt,@UpdatedAt);

--	SELECT @new_identity = (select ID from @Identity);

	select PatientID,
	DOB,
	Gender,
	BloodGroup,
	PatientImage,HealthConcern,MedicalHistory,InsuranceProvider,UserID,Istrash,CreatedAt,UpdatedAt
	from PatientProfile where PatientID = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END

-----Get Patient By Id--
Alter   PROCEDURE uspGetPatientById
	-- Add the parameters for the stored procedure here
	@UserID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from PatientProfile where UserID = @UserID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Patient dont exist',-1;
	end
	select * from PatientProfile where UserID = @UserID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO


------Adding doctordetails---
Alter  PROCEDURE uspAddDoctorProfile
	-- Add the parameters for the stored procedure here
@DoctorImage varchar(255),
@Age int,
@Gender varchar(25),
@Qualification varchar(150),
@Experience float,
@UserID int,
@RoleID int,
@CreatedAt datetime,
@UpdatedAt datetime,
@CategoryID int
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @DoctorID varchar;

	

	insert into DoctorProfile(DoctorImage ,
Age,
Gender ,
Qualification ,
Experience ,
UserID ,
RoleID ,

CreatedAt ,
UpdatedAt,CategoryID  ) output Inserted.DoctorID into @Identity
	values(@DoctorImage ,
@Age ,
@Gender ,
@Qualification ,
@Experience ,
@UserID ,
@RoleID ,
 
@CreatedAt ,
@UpdatedAt,@CategoryID );

--	SELECT @new_identity = (select ID from @Identity);

	select DoctorID,
	DoctorImage ,
Age,
Gender ,
Qualification ,
Experience ,
UserID ,
RoleID ,
CreatedAt ,
UpdatedAt,CategoryID  
	from DoctorProfile where DoctorID = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END

exec uspAddDoctorProfile 'jpg',39,'Female','MBBS','7 years',2,3,'2023-06-15 12:38:00','2023-06-15 12:38:00',2
insert into DoctorProfile(DoctorImage ,
Age,
Gender ,
Qualification ,
Experience ,
UserID ,
RoleID ,

CreatedAt ,
UpdatedAt,CategoryID  )
	values('jpg',39,'Female','MBBS','7 years',2,3,'2023-06-15 12:38:00','2023-06-15 12:38:00',2 );

select DoctorID,
	DoctorImage ,
Age,
Gender ,
Qualification ,
Experience ,
UserID ,
RoleID ,
CreatedAt ,
UpdatedAt,CategoryID  
	from DoctorProfile where DoctorID = 0;
-----Get Doctor By Id--
create   PROCEDURE uspGetDoctorById
	-- Add the parameters for the stored procedure here
	@UserID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from DoctorProfile where UserID = @UserID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Doctor dont exist',-1;
	end
	select * from DoctorProfile where UserID = @UserID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO


----GetAllDoctors---
CREATE   PROCEDURE uspGetAllDoctorProfiles
	-- Add the parameters for the stored procedure here
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;

	select * from DoctorProfile  
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO


---GetAll Patients---
CREATE   PROCEDURE uspGetAllPatients
	-- Add the parameters for the stored procedure here
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;

	select * from PatientProfile 
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO



-----Add doctor schedule with location-----
Create   PROCEDURE uspAddScheduleWithLocation
	-- Add the parameters for the stored procedure here
	@ScheduleTime time,
	@Location varchar(250),
	@DoctorID int
	
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @ScheduleId varchar;

	

	insert into ScheduleLocation(ScheduleTime,
	Location,
	DoctorID
	) output Inserted.ScheduleID into @Identity
	values(@ScheduleTime,
	@Location,
	@DoctorID);

--	SELECT @new_identity = (select ID from @Identity);

	select ScheduleId,
	ScheduleTime,
	Location,
	DoctorID
	from ScheduleLocation where ScheduleId = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END



------GetAllSchedule of doctor---
CREATE   PROCEDURE uspGetAllScheduleOfDOC
	-- Add the parameters for the stored procedure here
	@DoctorID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;

	select * from ScheduleLocation where DoctorID = @DoctorID; 
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO

exec uspGetAllScheduleOfDOC 8



------Add appointments---
Create  PROCEDURE uspAddAppointment
	-- Add the parameters for the stored procedure here
	@Concerns varchar(255),
@Appointmentdate Date,
@StartTime time,
@EndTime time,
@DoctorID int ,
@PatientID int ,
@ScheduleID int ,
@CreatedAt datetime,
@UpdatedAt datetime
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	DECLARE @AppointmentID varchar;

	

	insert into Appointment(Concerns ,
Appointmentdate ,
StartTime ,
EndTime ,
DoctorID  ,
PatientID  ,
ScheduleID  ,
CreatedAt ,
UpdatedAt ) output Inserted.AppointmentID into @Identity
	values(@Concerns ,
@Appointmentdate ,
@StartTime ,
@EndTime ,
@DoctorID  ,
@PatientID  ,
@ScheduleID  ,
@CreatedAt ,
@UpdatedAt );

--	SELECT @new_identity = (select ID from @Identity);

	select AppointmentID,
	Concerns ,
Appointmentdate ,
StartTime ,
EndTime ,
DoctorID  ,
PatientID  ,
ScheduleID  ,
CreatedAt ,
UpdatedAt 
	from Appointment where AppointmentID = (select ID from @Identity);
	set @result = 1;
COMMIT TRANSACTION;	

return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END


-----getDOCby docID---
Create   PROCEDURE uspGetDoctorByDocId
	-- Add the parameters for the stored procedure here
	@DoctorID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from DoctorProfile where DoctorID = @DoctorID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Doctor dont exist',-1;
	end
	select * from DoctorProfile where DoctorID = @DoctorID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END



----GetAppointment by patientID---

alter   PROCEDURE uspGetAppointmentByPatientID
	-- Add the parameters for the stored procedure here
	@PatientID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from Appointment where PatientID = @PatientID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Patient dont exist',-1;
	end
	select * from Appointment where PatientID = @PatientID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END



----Get appointment by DoctorID----

Create   PROCEDURE uspGetAppointmentByDocId
	-- Add the parameters for the stored procedure here
	@DoctorID int
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;
	if((select count(*) from Appointment where DoctorID = @DoctorID) = 0)
	begin
		set @result = 2; 
		throw 5000,'Doctor dont exist',-1;
	end
	select * from Appointment where DoctorID = @DoctorID;
	
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END



------Get all appoinments----
CREATE   PROCEDURE uspGetAllAppointments

AS

SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
	DECLARE @result int = 0;

	select * from Appointment
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
GO

Update DoctorProfile set DoctorImage='png' ,
Age=30,
Gender='Female' ,
Qualification='MBBS' ,
Experience=3.7 ,
UpdatedAt='2023-06-21',
CategoryID=2   where DoctorID=8;


exec uspUpdateDOCProflie 1,'png',34,'female','MBBS','3.5','2023-06-21', 2
------UpdateDocProfile----
alter PROCEDURE uspUpdateDOCProflie
	
	@DoctorID int,
	@DoctorImage varchar(255),
@Age int,
@Gender varchar(25),
@Qualification varchar(150),
@Experience float,
@UpdatedAt datetime,
@CategoryID int
	
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET XACT_ABORT on;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	DECLARE @Identity table (ID nvarchar(100));
	DECLARE @new_identity nvarchar(100);
	DECLARE @result int = 0;
	
	if((select count(*) from DoctorProfile where DoctorID = @DoctorID) = 0)
	begin
		set @result = 2; 
		throw 5000,'User dont exist',-1;
	end
	

	Update DoctorProfile set DoctorImage=@DoctorImage ,
Age=@Age,
Gender=@Gender ,
Qualification=@Qualification ,
Experience=@Qualification ,
UpdatedAt=@UpdatedAt,
CategoryID=@CategoryID   where DoctorID=@DoctorID;

--	SELECT @new_identity = (select ID from @Identity);

	select DoctorID,
	DoctorImage ,
Age,
Gender ,
Qualification ,
Experience ,
CreatedAt ,
UpdatedAt,CategoryID  
	from DoctorProfile where DoctorID = @DoctorID;
	set @result = 1;
COMMIT TRANSACTION;	
return @result;
END TRY
BEGIN CATCH
--SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
IF(XACT_STATE()) = -1
	BEGIN
		PRINT
		'transaction is uncommitable' + ' rolling back transaction'
		ROLLBACK TRANSACTION;
		print @result;
		return @result;
	END;
ELSE IF(XACT_STATE()) = 1
	BEGIN
		PRINT
		'transaction is commitable' + ' commiting back transaction'
		COMMIT TRANSACTION;
		print @result;
		return @result;
	END;
END CATCH
	
END
