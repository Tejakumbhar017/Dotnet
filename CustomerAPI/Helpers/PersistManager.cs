using CatalogAPI.Entities;
using System.Collections.Generic;
using System.Text.Json;

namespace CatalogAPI.Helpers;

public class PersistManager
{
    public static List<Customer> Load(string filePath)
    {
        List<Customer> customer =new List<Customer>();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            customer = JsonSerializer.Deserialize<List<Customer>>(json);
        }
        return customer;
    }

    public static bool Dump(string filePath , List<Customer> customer)
    {
        bool status = false;
        try
        {
            {
                string json = JsonSerializer.Serialize(customer, JsonSerializerOptions.Default);
                File.WriteAllText(filePath, json);
                status = true;
            }
        }
        catch (Exception ex)
        {
           
        }
        finally
        {

        }
        return status;
    }

}