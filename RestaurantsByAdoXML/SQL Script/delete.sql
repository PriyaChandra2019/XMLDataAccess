Create procedure spDeleteRestaurantsType     
(      
   @Id int      
)      
as       
begin      
   Delete from dbo.tblRestaurantsType where Id=@Id      
End