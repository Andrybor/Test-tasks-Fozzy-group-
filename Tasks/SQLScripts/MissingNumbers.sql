IF Object_id('tempdb..#test_table') IS NOT NULL
 DROP TABLE #test_table
 
CREATE TABLE #test_table
 (
    id INT
 )
 
GO
 
INSERT INTO #test_table
VALUES (1), (2), (8), (4), (9), (7), (3), (10) --<-- Отсутствуют числа 5 и 6
GO
 
SELECT *
FROM   #test_table  
 
GO

SELECT result =
(
    SELECT "text()" =
        iif(id1 < id2, CONVERT(VARCHAR(15), id1) +
        iif(id1 < (id2 - 1), '-' + CONVERT(VARCHAR(15), id2 - 1), ''), '')
    FROM
    (
        SELECT
            id1 = isnull(lag(id) OVER (ORDER BY id), 0) + 1,
            id2 = id
        FROM #test_table
    ) t
    WHERE ( id1 < id2 )
    ORDER BY id2
    FOR xml path('')
)
