using Target1.Models;
using Target1.Repository.IRepository;

namespace Target1.Repository.IRepository
{
    public interface IBankingCart3Repository : IRepository<BankingCart3>
    {
        int DecrementCount(BankingCart3 bankingCart3, int monthes);

        int IncrementCount(BankingCart3 bankingCart3, int monthes);
        int DecrementCounts(BankingCart3 bankingCart3, int Loan);
        void IncrementCounts(BankingCart3 bankingCart3, int Loan);
        //void DecrementLimit(Banks banks, int LimitL);
        void Save();
        void Update(BankingCart3 obj);
        void Update(Banks obj);
        //int IncrementlimitL(BankingCart3 bankingCart3, Banks banks);
        //void IncrementlimitL(BankingCart3 cart, int limitLine, int credit);
    }

}
