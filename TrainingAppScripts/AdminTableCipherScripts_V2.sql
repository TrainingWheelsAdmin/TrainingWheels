USE TrainingWheelsAdminDb
GO

--------------------------------CREATING MASTER KEY---------------------------------------------
IF (SELECT
    COUNT(*)
  FROM sys.symmetric_keys
  WHERE name LIKE '%DatabaseMasterKey%')
  = 0
BEGIN
  CREATE MASTER KEY ENCRYPTION BY PASSWORD = '1%ZAs|(*#<:J';
END

--------------------------------CREATING CERTIFICATE-------------------------------------------
IF (SELECT
    COUNT(*)
  FROM sys.certificates
  WHERE name = 'CredCert')
  = 0
BEGIN
  CREATE CERTIFICATE CredCert WITH SUBJECT = 'Credential Encryption Certificate';
END

------------------------------- CREATING SYMMETRIC KEY-----------------------------------------
IF (select count(*) from sys.symmetric_keys where name = 'CredKey') = 0
BEGIN
	CREATE SYMMETRIC KEY CredKey
	WITH ALGORITHM = AES_128
	ENCRYPTION BY CERTIFICATE CredCert;
END

-------------------------------

GRANT CONTROL ON CERTIFICATE::CredCert TO TrainingWheelsAdmin

GRANT VIEW DEFINITION ON SYMMETRIC KEY::CredKey TO TrainingWheelsAdmin

GRANT CREATE PROCEDURE TO TrainingWheelsAdmin