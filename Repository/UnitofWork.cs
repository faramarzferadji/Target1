using Target1.Areas.Identity.Data;
using Target1.Models;
using Target1.Repository.IRepository;

namespace Target1.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private ApplicationDbContext _db;
        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
      
            Banks = new BanksRepository(_db);
            BankingCart3 = new BankingCart3Repository(_db);
            applicationUser = new ApplicationUserRepository(_db);
            Customer = new CustomerRepository(_db);



        }
      
        public IBanksRepository Banks { get; private set; }
        public IBankingCart3Repository BankingCart3 { get; private set; }
        public IApplicationUser applicationUser { get; private set; }
        public ICustomerRepository Customer { get; private set; }





        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
