create procedure InsertDataInERTable
(@addressBookId int,
@firstName varchar(50),@lastName varchar(50),@address varchar(100),@city varchar(50),@state Varchar(30),@zipCode int,
@phoneNumber bigint,@emailId varchar(30),@date date,@personTypeId int
)
as 
begin 
set xact_abort on;
begin try
begin transaction;
declare @out int;
insert into Person values (@addressBookId,@firstName,@lastName,@address,@city,@state,@zipCode,@phoneNumber,@emailId,@date);
select @out = SCOPE_IDENTITY();
insert into PersonTypeMap values (@out,@personTypeId);
commit transaction;
end try
begin catch
if(xact_state())=-1
begin 
print N'The querys have some error!!'+'Rolling back transaction'
rollback transaction;
end;
if(xact_state())=1
begin
print N'The Transaction Is Done'+'Commiting Transaction'
commit transaction;
end;
end catch
end