using Target1.Models;

namespace Target1.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
        void Save();
    }
}

