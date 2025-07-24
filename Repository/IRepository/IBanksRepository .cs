using System.Linq.Expressions;
using Target1.Models;

namespace Target1.Repository.IRepository
{
    public interface IBanksRepository : IRepository<Banks>
    {
      public void DecrementLimit(Banks banks, int LimitL);
        void IncrementLimit(Banks banks, int LimitL);
        public void UpdateO(Banks obj, Expression<Func<Banks, object>> updatedProperty);
        void Update(Banks obj);
        void Save();
        void Attach(Banks banks);
        //void Attach(Banks banks);
        //int MAJ(int limitLine, BankingCart3 bankingCart3, Banks banks);
        //void MAJ(Banks cart, object limitLine);
        //void Update(object banks);


        //void Update(string? imagurl);
        //object SelectMany(Func<object, object> value);
    }

}

