IF Object_id('tempdb..#test_table') IS NOT NULL
 DROP TABLE #test_table
 
CREATE TABLE #test_table
 (
    NUMBER INT,
    NAME   VARCHAR(255)
 )
 
GO
 
INSERT INTO #test_table VALUES (1, 'Red') --<-- Полный дулбикат
INSERT INTO #test_table VALUES (2, 'Yellow')
INSERT INTO #test_table VALUES (3, 'Green')
INSERT INTO #test_table VALUES (1, 'Blue')
INSERT INTO #test_table VALUES (1, 'Red') --<-- Полный дулбикат
INSERT INTO #test_table VALUES (4, 'Black')
INSERT INTO #test_table VALUES (2, 'Red')

GO

delete x
from (
  select *, rn=row_number() over (partition by name order by number)
  from #test_table 
) x
where rn > 1;
 
 GO

SELECT *
FROM   #test_table  
GO