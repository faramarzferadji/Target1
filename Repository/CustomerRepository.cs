using Target1.Areas.Identity.Data;
using Target1.Models;
using Target1.Repository.IRepository;

namespace Target1.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {

            _db.SaveChanges();
        }

        public void Update(Customer obj)
        {
            _db.CustomerAffer.Update(obj);
        }
    }
}
