alter   PROCEDURE uspRegisterUser
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
GO
