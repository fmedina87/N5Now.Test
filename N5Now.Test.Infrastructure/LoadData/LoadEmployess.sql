BEGIN TRY
    BEGIN TRANSACTION;

     INSERT INTO [dbo].[Employees]([FirstName],[SecondName],[FirstLastName],[SecondLastName],[Code],[CreatedDate],[UpdatedDate],[IsActive],[Identification])
     VALUES('Juanito','Juan','Silva',null,'jsilva',GETDATE(),null,1,'1234560'),
           ('Pablito',null,'Cantador',null,'pcantador',GETDATE(),null,1,'1234561'),
		   ('homero',null,'simpson',null,'hsimpson',GETDATE(),null,1,'1234562');
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
