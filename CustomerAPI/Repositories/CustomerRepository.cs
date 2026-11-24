namespace CatalogAPI.Repository;
using CatalogAPI.Entities;
using CatalogAPI.Helpers;

public class CustomerRepository
{
    string filePath = @"E:\TAP\dotnet\CustomerSolutions\CustomerAPI\Data\Customer.json";

    public List<Customer> GetAll()
    {
        Console.WriteLine("get all method invoked");
        List<Customer> allCustomers = PersistManager.Load(filePath);
        return allCustomers;
    }
      public Customer GetById(int id)
    {
        List<Customer> allCustomers = GetAll();
        Customer theCustomer = null;

        for (int i = 0; i < allCustomers.Count; i++)
        {
            if (allCustomers[i].Id == id)
            {
                theCustomer = allCustomers[i];
                return theCustomer;
            }
        }
        return theCustomer;
    }
        public bool Create(Customer theCustomer)
    {
        bool status = false;
        List<Customer> allCustomers = GetAll();
        allCustomers.Add(theCustomer);
        PersistManager.Dump(filePath, allCustomers);
        status = true;
        return status;
    }

    
    public bool Update(Customer customerToUpdate)
    {
        bool status = false;

        List<Customer> allCustomers = GetAll();

        for (int i = 0; i < allCustomers.Count; i++)
        {
            if (allCustomers[i].Id == customerToUpdate.Id)
            {
                allCustomers[i] = customerToUpdate;

                PersistManager.Dump(filePath, allCustomers);

                status = true;
                break;
            }
        }

    return status;
    }
   
   public bool Delete(int id)
    {
        bool status = false;
        List<Customer> allCustomers = GetAll();
        Customer customer = GetById(id);

        if (customer != null)
        {
            allCustomers.RemoveAll(c => c.Id == id);
            PersistManager.Dump(filePath, allCustomers);
            status = true;
        }
        return status;
    }

}