CREATE PROCEDURE GetMyReviews
@userId INT,
@pageNumber INT, 
@pageSize   INT
AS 
BEGIN
WITH ctepaging 
     AS (SELECT *,
                Row_number() OVER(ORDER BY Id) AS rownum 
         FROM Review where UserId = @userId) 
SELECT * 
FROM   ctepaging 
WHERE  rownum BETWEEN ( @pageNumber - 1 ) * @pageSize + 1 AND
@pageNumber * @pageSize
END