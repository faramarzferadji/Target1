using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Target1.Areas.Identity.Data;
using Target1.Models;
using Target1.Repository.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Target1.Repository
{
    public class BanksRepository : Repository<Banks>, IBanksRepository
    {
        private ApplicationDbContext _db;


        public BanksRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Banks obj)
        {
            _db.BanksAffer.Update(obj);
            //_db.SaveChanges();
        }
        public void IncrementLimit(Banks banks, int LimitL)
        {

            banks.LimitLine += LimitL;


        }
        public void DecrementLimit(Banks banks, int LimitL)
        {

            banks.LimitLine -= LimitL;


        }


        public void UpdateO(Banks obj, Expression<Func<Banks, object>> updatedProperty)
        {
            // Check if the obj parameter is not null
            if (obj != null)
            {
                // Attach the obj to the context
                _db.BanksAffer.Attach(obj);
                // Mark the property as modified
                _db.Entry(obj).Property(updatedProperty).IsModified = true;
                // Save the changes
                _db.SaveChanges();
            }
        }



        public void Attach(Banks banks)
        {
            // Check if the banks parameter is not null
            if (banks != null)
            {
                // Attach the banks to the context
                _db.BanksAffer.Attach(banks);
            }
        }
    }
}
