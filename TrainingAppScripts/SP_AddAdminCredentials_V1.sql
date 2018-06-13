
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TrainingWheelsAdmin
-- Create date: 11/6/2018
-- Description:	InsertionOfUserNameandPasswordforAdmin
-- =============================================

CREATE PROCEDURE Carbon.SP_AddCred
	-- Add the parameters for the stored procedure here
	@TenantId UNIQUEIDENTIFIER, 
	@UserName VARCHAR(MAX),
	@Password VARCHAR(MAX),
	@AddedBy UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @CipherUserName VARBINARY(MAX);
	OPEN SYMMETRIC KEY CredKey  
	DECRYPTION BY CERTIFICATE CredCert;
	SET @CipherUserName=ENCRYPTBYKEY(KEY_GUID('CredKey'),@UserName);
	INSERT INTO Carbon.AdminCredentials (AdminCredentialsId,TenantId,UserName,Password,AddedBy,AddedOn,UpdatedBy,UpdatedOn,Status) VALUES (NEWID(),@TenantId,@CipherUserName,@Password,@AddedBy,GETDATE(),NULL,NULL,1)
END
GO

--EXEC Carbon.SP_AddCred @TenantId=null,@UserName='admin@training.com',@Password='F1F929AB09CA1DBD78F2A0660E58B562',@AddedBy='BDA9BC23-9D17-4F32-A1CE-0E75CAFAC562'
--PWD:2@Tcsad#3


