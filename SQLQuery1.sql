select top 10 * from (select 
row_number() over(order by uid)as rown,* from users)temp
where temp.rown>10*(177777-1)

--select * from titles limit((��ǰҳ��-1)*ÿҳ����,ÿҳ����);

---����������������

--����   �ۼ�����    �Ǿۼ�����

----or  ������ȫ��ɨ�� union  

----not in  in


declare @count int

set @count=1

while(@count<2000000)
begin

insert into users values('fsfsffsfsf',getdate())

set @count=@count+1

end

