USE TrainingWheelsAdminDb;

GO 

--tables :

--tenant_details, admin_user_details, admin_scopes, admin_tenants, admin_forms, admin_previleges

IF OBJECT_ID(N'Carbon.AdminScopes',N'U') IS NULL
CREATE TABLE Carbon.AdminScopes (
	AdminScope_Id UNIQUEIDENTIFIER NOT NULL,
	AdminScope_Name NVARCHAR(50) NOT NULL,
	AdminScope_Description NVARCHAR(150) NOT NULL,
	AdminScope_AddedOn DATETIME NOT NULL,
	AdminScope_AddedBy UNIQUEIDENTIFIER NOT NULL,
	AdminScope_UpdatedOn DATETIME NULL,
	AdminScope_UpdatedBy UNIQUEIDENTIFIER NULL,
	AdminScope_Status BIT NOT NULL
	CONSTRAINT [PK_AdminScope_Id] PRIMARY KEY CLUSTERED (AdminScope_Id ASC)
)
GO

IF OBJECT_ID(N'Carbon.AdminDetails',N'U') IS NULL
CREATE TABLE Carbon.AdminDetails (
	AdminDetail_Id UNIQUEIDENTIFIER NOT NULL,
	AdminDetail_AdminScopeId UNIQUEIDENTIFIER NOT NULL,
	AdminDetail_Name NVARCHAR(50) NOT NULL,
	AdminDetail_Description NVARCHAR(150) NOT NULL,
	AdminDetail_AddedOn DATETIME NOT NULL,
	AdminDetail_AddedBy UNIQUEIDENTIFIER NOT NULL,
	AdminDetail_UpdatedOn DATETIME NULL,
	AdminDetail_UpdatedBy UNIQUEIDENTIFIER NULL,
	AdminDetail_Status BIT NOT NULL
	CONSTRAINT [PK_AdminDetail_Id] PRIMARY KEY CLUSTERED (AdminDetail_Id ASC)
	CONSTRAINT [FK_AdminDetail_AdminScopeId] FOREIGN KEY (AdminDetail_AdminScopeId) REFERENCES Carbon.AdminScopes(AdminScope_Id)
)
GO

IF OBJECT_ID(N'Carbon.TenantDetails',N'U') IS NULL
CREATE TABLE Carbon.TenantDetails (
	TenantDetails_Id UNIQUEIDENTIFIER NOT NULL,
	TenantDetails_Name NVARCHAR(50) NOT NULL,
	TenantDetails_Description NVARCHAR(150) NULL,
	TenantDetails_TenantSite NVARCHAR(50) NULL,
	TenantDetails_TenantUrl NVARCHAR(50) NULL,
	TenantDetails_AddedOn DATETIME NOT NULL,
	TenantDetails_AddedBy UNIQUEIDENTIFIER NOT NULL,
	TenantDetails_UpdatedOn DATETIME NULL,
	TenantDetails_UpdatedBy UNIQUEIDENTIFIER NULL,
	TenantDetails_Status BIT NOT NULL
	CONSTRAINT [PK_TenantDetails_Id] PRIMARY KEY CLUSTERED (TenantDetails_Id ASC)
)
GO 

IF OBJECT_ID(N'Carbon.TenantAddress',N'U') IS NULL
CREATE TABLE Carbon.TenantAddress (
	TenantAddress_Id UNIQUEIDENTIFIER NOT NULL,
	TenantAddress_TenantId	UNIQUEIDENTIFIER NOT NULL,
	TenantAddress_CompanyName NVARCHAR NOT NULL,
	TenantAddress_DoorNo INT NULL,
	TenantAddress_StreetName NVARCHAR(50) NULL,
	TenantAddress_CityName NVARCHAR(50) NOT NULL,
	TenantAddress_CountryName NVARCHAR(50) NOT NULL,
	TenantAddress_ContactNumber NVARCHAR(50) NOT NULL,
	TenantAddress_EmailId NVARCHAR(100) NULL,
	TenantAddress_ContactPersonName NVARCHAR(200) NOT NULL
	CONSTRAINT [PK_TenantAddress_Id] PRIMARY KEY CLUSTERED (TenantAddress_Id ASC)
	CONSTRAINT [FK_TenantAddress_TenantId] FOREIGN KEY (TenantAddress_TenantId) REFERENCES Carbon.TenantDetails(TenantDetails_Id)
)
GO

IF OBJECT_ID(N'Carbon.AdminCredentials',N'U') IS NULL
CREATE TABLE Carbon.AdminCredentials (
	AdminCredentialsId UNIQUEIDENTIFIER NOT NULL,
	TenantId UNIQUEIDENTIFIER NULL,
	UserName VARBINARY(MAX) NOT NULL,
	Password NVARCHAR(MAX) NOT NULL,
	AddedBy UNIQUEIDENTIFIER NOT NULL,
	AddedOn DATETIME NOT NULL,
	UpdatedBy UNIQUEIDENTIFIER NULL,
	UpdatedOn DATETIME NULL,
	Status BIT NOT NULL	
	CONSTRAINT [PK_AdminCredentialsId] PRIMARY KEY CLUSTERED (AdminCredentialsId ASC)
	CONSTRAINT [FK_TenantId] FOREIGN KEY (TenantId) REFERENCES Carbon.TenantDetails(TenantDetails_Id)
)
GO





