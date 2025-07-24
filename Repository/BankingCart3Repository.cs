using Target1.Repository.IRepository;
using Target1.Areas.Identity.Data;
using Target1.Models;
using Target1.Repository;
using Target1.Repository.IRepository;


namespace Target1.Repository
{
    public class BankingCart3Repository : Repository<BankingCart3>, IBankingCart3Repository
    {
        private ApplicationDbContext _db;
        public BankingCart3Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(BankingCart3 bankingCart3, int monthes)
        {
            bankingCart3.Month -= monthes;
            return monthes;
        }
        public int IncrementCount(BankingCart3 bankingCart3, int monthes)
        {
            bankingCart3.Month += monthes;
            return monthes;
        }

        public int DecrementCounts(BankingCart3 bankingCart3, int Loan)
        {
            bankingCart3.Loan -= Loan;
            return Loan;

        }

        public void IncrementCounts(BankingCart3 bankingCart3, int Loan)
        {
            bankingCart3.Loan += Loan;
            //return Loan;
        }
        //public void DecrementLimit(Banks banks, int LimitL)
        //{

        //    banks.LimitLine -= LimitL;


        //}
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(BankingCart3 obj)
        {
            _db.BankingAffer3.Update(obj);
        }
        public void Update(Banks obj)
        {
            _db.BanksAffer.Update(obj);
        }
        //public int IncrementlimitL(BankingCart3 bankingCart3, Banks banks)
        //{
        //    banks.LimitLine = (int)bankingCart3.Credit;
        //    return banks.LimitLine;
        //}

        //public void IncrementlimitL(BankingCart3 cart, int limitLine, int credit)
        //{
        //    //banks.LimitLine = (int)bankingCart3.Credit;
        //    //return banks.LimitLine;
        //}
    }

}
