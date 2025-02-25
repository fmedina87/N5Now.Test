BEGIN TRY
    BEGIN TRANSACTION;

     INSERT INTO [dbo].[PermissionTypes]
           ([Name]
           ,[CreatedDate]
           ,[UpdatedDate]
           ,[IsActive])
     VALUES
           ('Type 1',GETDATE(),null,1),
		   ('Type 2',GETDATE(),null,1),
		   ('Type 3',GETDATE(),null,1),
		   ('Type 4',GETDATE(),null,1);
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;

    DECLARE @ErrorMessage NVARCHAR(MAX), @ErrorSeverity INT, @ErrorState INT;
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(), 
        @ErrorSeverity = ERROR_SEVERITY(), 
        @ErrorState = ERROR_STATE();

    -- Mostrar el error
    RAISERROR('Error en la migración: %s', @ErrorSeverity, @ErrorState, @ErrorMessage);
END CATCH
