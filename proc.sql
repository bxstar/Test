
/****** Object:  StoredProcedure [dbo].[proc_dispatch_item_click]    Script Date: 01/06/2014 20:07:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_dispatch_item_click]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_dispatch_item_click]
GO

USE [demo]
GO

/****** Object:  StoredProcedure [dbo].[proc_dispatch_item_click]    Script Date: 01/06/2014 20:07:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================                    
-- Author:  yrs                    
-- Create date: 2013-12-22              
-- Description: 分配点击任务                
-- =============================================    
CREATE PROC [dbo].[proc_dispatch_item_click]
(
    @max_address VARCHAR(50),
    @ip_address VARCHAR(50)
)
AS
BEGIN
    DECLARE @t TABLE
    (
    	increase_id INT IDENTITY(1,1),
        local_item_task_id UNIQUEIDENTIFIER,
        item_id BIGINT,
        nick VARCHAR(100),
        creative_one_title VARCHAR(100),
        creative_two_title VARCHAR(100),
        keyword VARCHAR(100)
    )
    
    INSERT INTO @t
    SELECT A.local_item_task_id,A.item_id,A.nick,A.creative_one_title,A.creative_two_title
    ,A.keyword
     FROM t_item_task A LEFT JOIN
    (
        SELECT COUNT(tic.local_item_task_id) click_count,tic.local_item_task_id FROM t_item_click tic
        WHERE --tic.local_item_task_id=A.local_item_task_id  AND
        DATEDIFF(DAY,tic.create_time,GETDATE())=0            --今天的点击
        AND tic.is_succeed  IS NULL OR tic.is_succeed=1        --点击成功的或正在执行点击的
        GROUP BY tic.local_item_task_id   
    ) B
       ON B.local_item_task_id = A.local_item_task_id
     
    WHERE A.is_enable=1 AND A.is_succeed IS NULL AND DATEDIFF(DAY,A.create_time,GETDATE())<=A.run_days
    AND isnull(B.click_count,0)<A.max_click
   
	DECLARE @i INT,@count INT
	SET @i=1
	SELECT @count =COUNT(1) FROM @t
	WHILE(@i<=@count)
		BEGIN
			IF(EXISTS(SELECT 1 FROM t_item_click tic INNER JOIN @t A ON A.local_item_task_id = tic.local_item_task_id 
			 WHERE tic.mac_address=@max_address AND A.increase_id=@i AND DATEDIFF(hh,tic.create_time,GETDATE())<24
			))
				DELETE FROM @t WHERE increase_id=@i
			SET @i=@i+1
		END

	IF(EXISTS(SELECT 1 FROM @t))
	BEGIN
	    INSERT INTO t_item_click
		(
			item_id,
			mac_address,
			ip_address,
			local_item_task_id,
			create_time,
			update_time
		)
		SELECT item_id,@max_address,@ip_address,local_item_task_id,GETDATE(),GETDATE() FROM @t 
	    
		SELECT * FROM @t t
	END

END

GO

