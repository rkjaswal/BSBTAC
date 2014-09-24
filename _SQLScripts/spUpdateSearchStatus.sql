-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>

-- Description:	<Description,,>

-- =============================================

CREATE PROCEDURE [dbo].[spUpdateSearchStatus] 

@SearchDefinitionId int,

@UploadDetailId int,

@DebtCode int,

@Title varchar(50),

@Forename varchar(50),

@Surname varchar(50),

@Othername varchar(50),

@DOB datetime,

@BuildingNo varchar(50),

@BuildingName varchar(50),

@Locality varchar(50),

@Sublocality varchar(50),

@Posttown varchar(50),

@Postcode varchar(50),

@Type tinyint,

@Status tinyint,

@LastUpdatedDatetime datetime,

@FailureReason varchar(MAX)

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;



    -- Insert statements for procedure here

	UPDATE SearchDefinition

	SET [Status] = @Status, 

		LastUpdatedDatetime = @LastUpdatedDatetime



	WHERE SearchDefinitionId = @SearchDefinitionId

END
