Create procedure spUpdateRestaurantsType      
(      
   @Id INTEGER ,    
   @RestaurantName varchar(20),
   @CuisineType varchar(20),    
   @City varchar(20),    
   @Rating varchar(20),    
   @Contact varchar(20) 
   )
as      
begin      
   Update dbo.tblRestaurantsType      
   set @RestaurantName=@RestaurantName,
   @CuisineType=@CuisineType,    
   @City=@City,    
   @Rating=@Rating,    
   @Contact=@Contact    
   where Id=@Id      
End