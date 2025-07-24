using Target1.Areas.Identity.Data;
using Target1.Models;

namespace Target1.Repository.IRepository
{
    public interface IUnitofWork
    {
    
        IBanksRepository Banks { get; }
        IBankingCart3Repository BankingCart3 { get; }
        IApplicationUser applicationUser { get; }
        ICustomerRepository Customer { get; }

        //object Entry(Banks banks);

        //object Banks(Func<object, object> value);
        //object Entry(Banks banks);





        //IShipHeadRepository shipHead { get; }

        void Save();
    }
}
