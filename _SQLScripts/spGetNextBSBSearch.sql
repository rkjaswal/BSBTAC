-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>

-- Description:	<Description,,>

-- =============================================



CREATE PROCEDURE [dbo].[spGetNextBSBSearch] 

@LastUpdatedDatetime datetime

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	DECLARE @SearchDefinitionId INT;

    -- Insert statements for procedure here

	SELECT @SearchDefinitionId = SearchDefinitionId

	FROM SearchDefinition

	WHERE [Status] = 1

	AND [Type] = 1;



	IF @SearchDefinitionId > 0

	BEGIN

		UPDATE SearchDefinition

		SET [Status] = 2, LastUpdatedDatetime = @LastUpdatedDatetime

		WHERE SearchDefinitionId = @SearchDefinitionId



		SELECT [SearchDefinitionId]

			  ,[UploadDetailId]

			  ,[DebtCode]

			  ,[Title]

			  ,[Forename]

			  ,[Surname]

			  ,[Othername]

			  ,[DOB]

			  ,[BuildingNo]

			  ,[BuildingName]

			  ,[Locality]

			  ,[Sublocality]

			  ,[Posttown]

			  ,[Postcode]

			  ,[Type]

			  ,[Status]

			  ,[LastUpdatedDatetime]

			  ,[FailureReason]

		FROM SearchDefinition

		WHERE SearchDefinitionId = @SearchDefinitionId

	END

END