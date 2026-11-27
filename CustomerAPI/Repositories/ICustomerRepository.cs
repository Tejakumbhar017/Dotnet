namespace CustomerAPI.Repositories;
using CustomerAPI.Entities;
using CustomerAPI.Helpers;
 
public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer GetById(int id);
    bool Create(Customer theCustomer);
    bool Update(Customer customertoUpdate , int id);
    bool Delete(int id); 
}