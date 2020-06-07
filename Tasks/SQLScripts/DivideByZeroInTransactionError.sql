IF Object_id('tempdb..#test_tran') IS NOT NULL
 DROP TABLE #test_tran
 
CREATE TABLE #test_tran
 (
    id   INT,
    name VARCHAR(255)
 )
GO
 
----------------------------------------
--If an error occurs, the transaction is not rolled back
GO

 BEGIN TRY
 BEGIN TRANSACTION
 DECLARE @a FLOAT = 1 / 0.0
 INSERT INTO #test_tran VALUES (1, 'Красный')

    COMMIT TRAN -- Transaction Success!
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN --RollBack in case of Error
END CATCH


SELECT * FROM   #test_tran