USE TrainingWheelsAdminDb
GO

IF COL_LENGTH('schemaName.Carbon.TenantAddress', 'TenantAddress_Status') IS NULL
BEGIN
    ALTER TABLE Carbon.TenantAddress ADD TenantAddress_Status BIT NOT NULL
END
--