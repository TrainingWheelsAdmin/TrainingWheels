DECLARE @CountVal INT;

SELECT @CountVal=COUNT(*) FROM Carbon.AdminScopes;

IF (@CountVal<=0)
BEGIN
	INSERT INTO Carbon.AdminScopes (AdminScope_Id,AdminScope_Name,AdminScope_Description,AdminScope_AddedBy,AdminScope_AddedOn,AdminScope_UpdatedBy,AdminScope_UpdatedOn,AdminScope_Status) VALUES (NEWID(),'SuperAdmin','Scope for create, alter, deletes and manages all tenants.',NEWID(),GETDATE(),NULL,NULL,1)
END

SELECT @CountVal=COUNT(*) FROM Carbon.AdminDetails;

IF (@CountVal<=0)
BEGIN

	INSERT INTO [Carbon].[AdminDetails]
           ([AdminDetail_Id]
           ,[AdminDetail_AdminScopeId]
           ,[AdminDetail_Name]
           ,[AdminDetail_Description]
           ,[AdminDetail_AddedOn]
           ,[AdminDetail_AddedBy]
           ,[AdminDetail_UpdatedOn]
           ,[AdminDetail_UpdatedBy]
           ,[AdminDetail_Status])
		VALUES
           ('BDA9BC23-9D17-4F32-A1CE-0E75CAFAC562'
           ,'16854134-1E71-430F-9569-4F9A258A1959'
           ,'TrainingWheelsAdmin'
           ,'Super Admin having complete scope on tenants'
           ,GETDATE()
           ,'BDA9BC23-9D17-4F32-A1CE-0E75CAFAC562'
           ,NULL
           ,NULL
           ,1)
END