using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Entities;

public class Customer
{
    public int Id{get;set;}
    
    [Required]
    public string Customer_Name{get;set;}
    
    public string Phone_No{get;set;}

    public int Age{get;set;}
}