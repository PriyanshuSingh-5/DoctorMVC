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