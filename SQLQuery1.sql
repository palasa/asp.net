select top 10 * from (select 
row_number() over(order by uid)as rown,* from users)temp
where temp.rown>10*(177777-1)

--select * from titles limit((当前页码-1)*每页行数,每页行数);

---海量数据性能问题

--索引   聚集索引    非聚集索引

----or  会引起全表扫描 union  

----not in  in


declare @count int

set @count=1

while(@count<2000000)
begin

insert into users values('fsfsffsfsf',getdate())

set @count=@count+1

end

