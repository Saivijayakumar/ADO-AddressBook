create procedure UpdatePhoneNumber
@firstName varchar(50),
@lastName varchar(50),
@PhoneNumber bigint
as 
begin
update Person set PhoneNumber=@PhoneNumber where PersonID= (Select PersonID from Person where FirstName=@firstName and LastName=@lastName);
end;
