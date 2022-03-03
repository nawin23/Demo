USE [StepUp]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspLogin]
(@PsNumber INT,@Password VARCHAR(50))
AS 
BEGIN
	BEGIN TRY
	
		IF @PsNumber  IS NOT NULL and @Password IS NOT NULL 
		BEGIN
		INSERT INTO LoginUser VALUES(@PsNumber , @Password)
		SELECT @PsNumber= [PsNumber] FROM StepUp.dbo.LoginUser where PsNumber = @PsNumber and Password = @Password
          SELECT * FROM StepUp.dbo.LoginUser
		RETURN 1
		END
		ELSE
		RETURN -2
	END TRY
	BEGIN CATCH
		RETURN -99
    END CATCH
END
