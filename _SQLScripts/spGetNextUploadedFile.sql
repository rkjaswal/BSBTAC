-- =============================================



-- Author		Author,,Name



-- Create date Create Date,,



-- Description	Description,,



-- =============================================



CREATE PROCEDURE [dbo].[spGetNextUploadedFile] 

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	DECLARE @UploadDetailId INT;

    -- Insert statements for procedure here

	SELECT @UploadDetailId = UploadDetailId

	FROM UploadDetail

	WHERE [Status] = 1;



	IF @UploadDetailId  0

	BEGIN

		UPDATE UploadDetail

		SET [Status] = 2

		WHERE UploadDetailId = @UploadDetailId



		SELECT [UploadDetailId]

			  ,[Filename]

			  ,[Status]

			  ,[Type]

			  ,[UploadedBy]

			  ,[UploadDatetime]

		FROM UploadDetail

		WHERE UploadDetailId = @UploadDetailId

	END

END