Create procedure spAddRestaurantsType   
(      
    @RestaurantName varchar(20),
	@CuisineType varchar(20),    
    @City varchar(20),    
    @Rating varchar(20),    
    @Contact varchar(20)   
)

as     
Begin     
    Insert into tblRestaurantsType (RestaurantName,CuisineType,City,Rating,Contact)     
    Values (@RestaurantName,@CuisineType,@City,@Rating,@Contact)     
End