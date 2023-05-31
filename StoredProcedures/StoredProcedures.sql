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


