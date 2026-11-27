namespace CustomerAPI.Services;
using CustomerAPI.Entities;

public interface ICustomerServices
{
    List<Customer> GetAll();
    Customer GetById(int id);
    bool Create(Customer theCustomer);
    bool Update(Customer customer , int id);
    bool Delete(int id);
}