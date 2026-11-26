namespace CustomerAPI.Services;
using CustomerAPI.Entities;
using CustomerAPI.Repositories;


public class CustomerServices : ICustomerServices
{
    private ICustomerRepository _repository;

    public CustomerServices(ICustomerRepository repo)
    {
        this._repository = repo;
    }

    public List<Customer> GetAll()
    {
        List<Customer> customer = new List<Customer>();
        customer = _repository.GetAll();
        return customer;
    }

    public Customer GetById(int id)
    {
        Customer customer = new Customer();
        customer = this._repository.GetById(id);
        return customer;
    }

    public bool Create(Customer customer)
    {
        bool status = this._repository.Create(customer);
        return false;
    }

    public bool Update(Customer theCustomer, int id)
    {
        if (id != theCustomer.Id)
        {
            return false;
        }
        bool status=this._repository.Update(theCustomer , id);
        return status;
    }
    public bool Delete(int id)
    {

        return this._repository.Delete(id);
    }

}