create procedure RetriveAllData
as 
begin
select p.PersonID,concat(p.FirstName,'.',p.LastName)as Name,concat(p.Address,',',p.City,',',p.State,',',p.ZipCode) as Address,p.PhoneNumber,p.EmailID,p.AddDate,
pt.PersonTypeID,pt.PersonType,ab.AddressBookID ,ab.AddressBookName
from AddressBook ab,Person p,PersonType pt,PersonTypeMap ptm
where ab.AddressBookID=p.AddressBookID  and p.PersonID=ptm.PersonID and ptm.PersonTypeID=pt.PersonTypeID;
end