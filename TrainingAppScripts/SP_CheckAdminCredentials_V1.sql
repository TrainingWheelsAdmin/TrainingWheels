
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TrainingWheelsAdmin
-- Create date: 12/6/2018
-- Description:	ChecksWhetherCredExists
-- =============================================

CREATE PROCEDURE Carbon.SP_CheckCred
	-- Add the parameters for the stored procedure here
	@TenantId UNIQUEIDENTIFIER, 
	@UserName VARCHAR(MAX),
	@Password VARCHAR(MAX)
AS
BEGIN
	DECLARE @OpenKeyCount INT;
	DECLARE @CredCount INT;
	DECLARE @Result VARCHAR = 'false';
	
	select @OpenKeyCount=COUNT(*) from sys.openkeys where key_name ='CredKey'
	IF @OpenKeyCount <= 0
	BEGIN
		OPEN SYMMETRIC KEY CredKey	
		DECRYPTION BY CERTIFICATE CredCert;
	END

	IF @TenantId IS NULL
	BEGIN
		SELECT @CredCount= COUNT(*) from Carbon.AdminCredentials where Convert(varchar,DECRYPTBYKEY(UserName))=@UserName AND Password=@Password and TenantId IS NULL and Status=1;
	END

	ELSE
	BEGIN
		SELECT @CredCount= COUNT(*) from Carbon.AdminCredentials where Convert(varchar,DECRYPTBYKEY(UserName))=@UserName AND Password=@Password and TenantId = @TenantId and Status=1;
	END

	CLOSE SYMMETRIC KEY CredKey

	IF @CredCount <> 1
	BEGIN
		SET @Result='false';
	END

	ELSE
	BEGIN
		SET @Result='true';
	END

	SELECT @Result AS RESULT;
END
GO





